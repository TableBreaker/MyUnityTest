Shader "Custom/VoidEffect"
{
    Properties
    {
        _UV0Speed ("Speed", float) = 0.0
        [HDR]_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _MainTex ("Texture", 2D) = "white" {}
        _DissolveCutoff ("Dissolve Cutoff", Range(0, 1)) = 0.0
        _DissolveTex ("DissolveTex", 2D) = "white" {}
        _AlphaSpeed ("Alpha Speed", float) = 0.0
        _AlphaCutoff ("Alpha Cutoff", Range(0, 1)) = 0.0
        _AlphaTex ("AlphaTex", 2D) = "white" {}
        _LightSpeed ("Light Speed", float) = 0.0
        [HDR]_LightColor ("Light Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _LightTex ("LightTex", 2D) = "black" {}
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 100
        ColorMask RGB
        Blend SrcAlpha OneMinusSrcAlpha
        Lighting Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma instancing_options procedural:vertInstancingSetup

            #include "UnityCG.cginc"
            #include "UnityStandardParticleInstancing.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                half4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 uv1 : TEXCOORD1;
                float4 vertex : SV_POSITION;
                half4 color : COLOR;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            float _UV0Speed;
            float _UV1Speed;
            half4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _DissolveTex;
            float4 _DissolveTex_ST;
            float _AlphaCutoff;
            float _AlphaSpeed;
            sampler2D _AlphaTex;
            float4 _AlphaTex_ST;
            float _LightSpeed;
            half4 _LightColor;
            sampler2D _LightTex;
            float4 _LightTex_ST;
            half _DissolveCutoff;

            v2f vert (appdata v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_OUTPUT(v2f, o); 
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.uv.zw = TRANSFORM_TEX(v.texcoord, _DissolveTex);
                o.uv1.xy = TRANSFORM_TEX(v.texcoord, _AlphaTex);
                o.uv1.zw = TRANSFORM_TEX(v.texcoord, _LightTex);
                o.color = v.color;
                vertInstancingColor(o.color);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half2 offset = half2(_Time.y * _UV0Speed, 0.0);
                
                half4 dissolveCol = tex2D(_DissolveTex, i.uv.zw + offset);
                clip(dissolveCol.r - _DissolveCutoff);

                half2 alphaOffset = half2(_Time.y * _AlphaSpeed, 0.0);
                half4 alpha = tex2D(_AlphaTex, i.uv1.xy + alphaOffset);
                clip(alpha.r - _AlphaCutoff);
                
                half4 col = tex2D(_MainTex, i.uv.xy + offset) * i.color;
                col *= 2.0 * _Color;

                half2 lightOffset = half2(_Time.y * _LightSpeed, 0.0);
                half4 lightCol = tex2D(_LightTex, i.uv1.zw + lightOffset);

                lightCol *= _LightColor;

                col = half4(lightCol.rgb + col.rgb, col.a);
                //finalColor = saturate(finalColor);
                return col;
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}
