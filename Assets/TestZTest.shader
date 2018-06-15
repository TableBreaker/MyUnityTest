Shader "Custom/TestZTest"
{
	subshader
	{
		Tags { "Queue" = "Geometry-1" "RenderType" = "DepthMask" }
		Lighting Off
		Pass
		{
			ZWrite On // actually it's the default value
			ZTest LEqual // actually it's the default value
			ColorMask 0
		}
	}
}
