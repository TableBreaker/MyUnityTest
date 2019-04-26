Shader "Custom/CartoonDissolve"
{
    Properties
	{
		//Material Properties
		_Color("Color", Color) = (0.931, 0.931, 0.931, 1)
		_AdjustColor("AdjustColor", Color) = (0,0,0,1)
		_MainTex("Diffuse", 2D) = "white" {}
		_LightArea("LightArea", Float) = 0.5
		_ShadowColor("ShadowColor", Color) = (0.5,0.5,0.5,1)
		
		_Shininess("Shininess",Float) = 10
		_SpecularThreshold("SpecularThreshold", Float) = 0.5
		_SpecularMulti("SpecularMulti",Float) = 0.2
		_SpecularColor("SpecularColor", Color) = (1,1,1,1)
		[Toggle(_EMISSION)]_UseEmission("UseEmission", Float) = 0
		_Emission("Emission", Float) = 1
		[Toggle(_EMISSION_ANIM)]_EmissionAnim("EmissionAnim", Float) = 0
		_EmissionAnimFreq("EmissionAnimFreq", Float) = 1
		_BloomFactor("BloomFactor", Float) = 1
		_DitherAlpha("DitherAlpha", Range(0,1)) = 1
		_DitherTex("Dither", 2D) = "white"{}

		_RimStrength("RimStength", Range(0,1)) = 0
		_RimColor("RimColor", Color) = (1,1,1,1)
		_RimRange("RimRange", Float) = 4

		_LightDir("DefaultLightDir", Vector) = (0,0,-1)
		_LightColor("DefaultLightColor",Color) = (1,1,1,1)

		_NoiseTexture("Dissolve Noise", 2D) = "white" {}
		_DissolveLevel("Dissolve Level", Range(0, 1)) = 0
		[HDR]_DissolveColor("Dissolve Color", Color) = (1, 1, 1, 1)
		[HDR]_EdgeColor("Dissolve Edge Color", Color) = (1, 1, 1, 1)
		_EdgeWidth("Dissolve Edge", Range(0, 1)) = 0.8
		_EdgeColorFactor("Edge Color Factor", Range(0, 1)) = 0.08
	}
	SubShader
	{
		Tags {"RenderType" = "Opaque" }
		Pass
		{
			NAME "LIGHTING"
			Tags {"LightMode" = "ForwardBase"}


			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#pragma target 3.0
			#pragma shader_feature _EMISSION 
			#pragma shader_feature _EMISSION_ANIM

			#include "UnityCG.cginc"
			#include "UnityShaderVariables.cginc"
			#include "Lighting.cginc"
			#include "Cartoon.cginc"

			half4 _Color;
			half4 _AdjustColor;
			sampler2D _MainTex;

			float4 _MainTex_ST;
			half _LightArea;
			half4 _ShadowColor;
			half _SpecularThreshold;
			half4 _SpecularColor;
			half _Shininess;
			half _SpecularMulti;
			half _BloomFactor;

			half4 _RimColor;
			half _RimRange;
			half _RimStrength;

			half4 _LightColor;
			half3 _LightDir;

		#ifdef _EMISSION
			half _Emission;
			//half _EmissionBloomFactor;
		
		#endif
		#ifdef _EMISSION_ANIM
			half _EmissionAnimFreq;
		#endif

			sampler2D _DitherTex;
			half _DitherAlpha;
			
			sampler2D _NoiseTexture;
            float4 _NoiseTexture_ST;
			half _EdgeWidth;
			half _DissolveLevel;
			half4 _DissolveColor;
			half4 _EdgeColor;
			float _EdgeColorFactor;

			CartoonV2fLite vert(CartoonVertexInputLite v)
			{
				CartoonV2fLite o;
				float4 worldPos = mul(unity_ObjectToWorld, v.vertex);

				float4 projPos = mul(unity_MatrixVP, float4(worldPos.xyz, 1.0));
				

				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = worldPos.xyz;
				o.pos = projPos;
				o.uv = v.texcoord;
				o.dither = DitherVS(projPos, _ProjectionParams.x);
				return o;
			}

			float4 frag(CartoonV2fLite i) :SV_Target
			{
				DitherPS(i.dither, _DitherTex, _DitherAlpha);

				float2 uv = TRANSFORM_TEX(i.uv, _MainTex);
                half2 noiseuv = TRANSFORM_TEX(i.uv,_NoiseTexture);
            	half4 noise = tex2D(_NoiseTexture, noiseuv);
				clip(noise.r - _DissolveLevel);
                
				half3 worldNormal = normalize(i.worldNormal);
				half3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos);
				half3 lightDir = normalize(-_LightDir);
				half3 h = normalize(viewDir + lightDir);
				half nh = clamp(dot(worldNormal, h), 0, 1);
				half specular = pow(nh, _Shininess);
				half nv = dot(viewDir, worldNormal);

				half nl = dot(worldNormal, lightDir);
				nl = nl * 0.5 + 0.5;

				half4 diffTexColor = tex2D(_MainTex, uv);
				half4 color = diffTexColor;

				color = StepColor(nl, _LightArea, color * _ShadowColor, color);

				half4 specularColor = 0;
				specularColor = StepColor(_SpecularThreshold, specular, _SpecularColor * _SpecularMulti, specularColor);
				color += specularColor;
				half4 emissionColor = 0;
		#ifdef _EMISSION
			   emissionColor = diffTexColor * _Emission * diffTexColor.a;
			   color.rgb = color * (1.0 - diffTexColor.a);
		#endif		
		#ifdef _EMISSION_ANIM
				emissionColor.xyz = (sin(_Time.y * _EmissionAnimFreq) * 0.5 + 0.5) * emissionColor.xyz;
		#endif
				
				color *= _LightColor * _BloomFactor * _Color;
				color += emissionColor;
				color.a = _Color.a;
				color.xyz = _AdjustColor + (1.0 - _AdjustColor)*color;
				color.xyz = RimLight(color.xyz, _RimColor, _RimStrength, _RimRange, nv);
				half4 finalColor = DissolvePS(noise, color, _DissolveColor, _EdgeColor, i.uv.z, _EdgeWidth, _EdgeColorFactor);
				return finalColor;
			}
			ENDCG
		}
		
	}
    Fallback "Diffuse"
}
