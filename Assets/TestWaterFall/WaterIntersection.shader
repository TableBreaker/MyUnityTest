Shader "Unlit/WaterIntersection"
{
	Properties
	{
		_Color("Main Color", color) = (1, 1, 1, .5)
		_IntersectionColor("Intersection Color", color) = (1, 1, 1, .5)
		_IntersectionThresholdMax("Intersection Threshold Max", Range(0.1, 10)) = 0.5
		_DisplGuide("Displacement guide", 2D) = "white" {}
		_DisplAmount("Displacement amount", float) = 0
		_WaveSpeed("Wave Speed", float) = 1.0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
		LOD 100

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			Zwrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float2 displUV : TEXCOORD1;
				float4 scrPos : TEXCOORD2;		
			};

			sampler2D _CameraDepthTexture;
			float4 _Color;
			float4 _IntersectionColor;
			float _IntersectionThresholdMax;
			sampler2D _DisplGuide;
			float4 _DisplGuide_ST;
			float _WaveSpeed;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.vertex.y += 0.5 * sin(o.vertex.x * 5 + _Time.y);

				o.scrPos = ComputeScreenPos(o.vertex);
				o.displUV = TRANSFORM_TEX(v.uv, _DisplGuide);
				o.uv = v.uv;

				return o;
			}
			
			half _DisplAmount;

			fixed4 frag (v2f i) : SV_Target
			{
				float depth = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, i.scrPos));

				float2 displ = tex2D(_DisplGuide, i.displUV - _Time.y / 5).xy;
				displ = ((displ * 2) - 1) * _DisplAmount;

				float diff = (saturate(_IntersectionThresholdMax * (depth - i.scrPos.w) + displ));

				fixed4 col = lerp(_IntersectionColor, _Color, step(0.5, diff));

				return col;
			}
			ENDCG
		}
	}
	Fallback "VertexLit"
}
