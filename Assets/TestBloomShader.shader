Shader "Unlit/TestBloomShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BloomScale ("BloomScale", Range(0, 1)) = 0
		_BloomThreshold ("BloomThreshold", Range(0.25, 0.707)) = 0.45
	}
	SubShader
	{
		Tags { "Queue"="Overlay" }
		LOD 100

		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
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
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _BloomScale;
			float _BloomThreshold;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				float2 relaUV = i.uv - 0.5;
				float dis = sqrt(dot(relaUV, relaUV));
				col.rgb += _BloomScale;
				col.a -= 15 * (dis - _BloomThreshold);
				return saturate(col);
			}
			ENDCG
		}
	}
}
