
struct CartoonVertexInput
{
	float4 vertex:POSITION;
	half4 color:COLOR;
	half3 normal:NORMAL;
	float2 texcoord:TEXCOORD0;
};


struct CartoonV2f
{
	float4 pos:SV_POSITION;
	half4 color:COLOR;
	float2 uv:TEXCOORD0;
	float3 worldPos:TEXCOORD1;
	half4 worldNormal:TEXCOORD2;
	float4 dither:TEXCOORD3;
	UNITY_FOG_COORDS(4)
};

struct CartoonVertexInputLite
{
	float4 vertex:POSITION;
	half3 normal:NORMAL;
	float4 texcoord:TEXCOORD0;
};


struct CartoonV2fLite
{
	float4 pos:SV_POSITION;
	float4 uv:TEXCOORD0;
	float3 worldPos : TEXCOORD1;
	half3 worldNormal : TEXCOORD2;
	float4 dither:TEXCOORD3;
	UNITY_FOG_COORDS(4)
};

inline half4 StepColor(half left, half right, half4 leftColor, half4 rightColor)
{
	// if( left <= right ) color = leftColor; else color = rightColor;
	return lerp(rightColor, leftColor, step(left, right));
}

float4 DitherVS(float4 projPos, half flip)
{
	float4 info = projPos / projPos.w * 0.5 + 0.5;
	return info;
}

inline half4 DissolvePS(half noise, half4 color, half4 dissolveColor, half4 edgeColor, half dissolveLevel, half edgeWidth, float colorFactor)
{
	float percentage = dissolveLevel / noise;
	float lerpEdge = sign(percentage - colorFactor - edgeWidth);
	fixed3 _edgeColor = lerp(edgeColor.rgb, dissolveColor.rgb, saturate(lerpEdge));
	float lerpOut = sign(percentage - edgeWidth);
	fixed3 colorOut = lerp(color, _edgeColor, saturate(lerpOut));
	return fixed4(colorOut, 2);

	//	half lerpFactor = saturate((edgeWidth - (noise - dissolveLevel)) / edgeWidth);
	//	edgeColor = lerp(color, edgeColor, lerpFactor);
	//	edgeColor *= colorFactor;
	//	color = StepColor(noise - dissolveLevel, edgeWidth, edgeColor, color);
	//	return color;
}

inline void DitherPS(float4 screenPos, sampler2D tex, float dither)
{
	screenPos.xy *= _ScreenParams.xy;
	screenPos.xy *= 0.25;
	half y = frac(screenPos.y);
	half x = frac(screenPos.x);

	half d = tex2D(tex, float2(x, y));
	clip(dither - d + 0.01);
}

inline half4 CartoonDiffuse(inout CartoonV2f i, half4 diffTex, half4 lightTex, half shadowArea, half4 shadowColor, half secondShadowArea, half4 secondShadowColor)
{
	half lightinfo = lightTex.y;
	lightinfo *= i.color.x;
	half nl = i.worldNormal.w;
	half light = (nl + lightinfo)* 0.5;

	half4 firstColorBranch = StepColor(light, secondShadowArea, diffTex * secondShadowColor, diffTex * shadowColor);
	half4 secndColorBranch = StepColor(light, shadowArea, diffTex * shadowColor, diffTex);
	diffTex = StepColor(lightinfo, 0.1, firstColorBranch, secndColorBranch);

	// if (lightinfo < 0.1)
	// {
	// 	if (light < secondShadowArea) 
	//  {
	// 		diffTex *= secondShadowColor;
	// 	}
	// 	else
	//  {
	// 		diffTex *= shadowColor;
	// 	}
	// 	diffTex = StepColor(light, secondShadowArea, diffTex * secondShadowColor, diffTex * shadowColor);
	// }
	// else
	// {
	// 	if(light < shadowArea)
	// 	{
	// 		diffTex *= shadowColor;
	// 	}
	// }

	return diffTex;
}

inline half4 CartoonSpecular(inout CartoonV2f i, half4 lightTex, half specularStrength, half4 specularColor, half specularMulti)
{
	half4 specular;
	half specularThrushold = 1.0 - lightTex.z;
	specular = StepColor(specularThrushold, specularStrength, specularColor * specularMulti * lightTex.x, 0);

	return specular;
}

inline half3 RimLight(half3 color, half3 rimColor, half rimStrength, half rimRange, half nv)
{
	float strength = pow(abs(1.0-nv)*rimStrength, rimRange);
	return strength * rimColor + (1 - strength)*color;
}
