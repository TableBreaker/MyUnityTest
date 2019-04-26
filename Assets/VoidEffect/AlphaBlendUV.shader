Shader "GCGame/Particles/AlphaBlendUV"{
Properties {
    [Toggle(USE_CUTOFF)]_UseCutoff("Use Cut Off", Float) = 0

    [HDR]_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
    _MainTex ("Particle Texture", 2D) = "white" {}
    _UVSpeed("UVOffsetSpeed", Vector) = (1,0,0,0)

    _Cutoff("Cutoff", Float) = 0.5
    [MaterialEnum(Off,0,Front,1,Back,2)]_Cull("Cull", Int) = 0
}

Category {
    Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
    Blend SrcAlpha OneMinusSrcAlpha
    ColorMask RGB
    Cull [_Cull] Lighting Off ZWrite Off

    SubShader {
        Pass {

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
            #pragma multi_compile_particles
            #pragma multi_compile_fog
            #pragma multi_compile __ USE_CUTOFF

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            half4 _TintColor;
            half _Cutoff;
            float2 _UVSpeed;

            struct appdata_t {
                float4 vertex : POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                UNITY_VERTEX_OUTPUT_STEREO
            };

            

            v2f vert (appdata_t v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = v.color;

                float2 texcoord = v.texcoord.xy + _UVSpeed * _Time.g;
                o.texcoord = TRANSFORM_TEX(texcoord,_MainTex);
                
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {

                half4 col = i.color * tex2D(_MainTex, i.texcoord);
                col *= 2.0 * _TintColor;

                #if defined (USE_CUTOFF)
                clip(col.a - _Cutoff);
                #endif

                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
	Fallback "Mobile/Particles/Alpha Blend"
}
}
