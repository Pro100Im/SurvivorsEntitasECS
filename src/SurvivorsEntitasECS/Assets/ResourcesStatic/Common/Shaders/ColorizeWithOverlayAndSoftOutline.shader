Shader "Universal Render Pipeline/2D/Custom/ColorizeOverlayOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color Tint", Color) = (1,1,1,1)
        _Intensity ("Color Intensity", Range(0,1)) = 0.5
        _OverlayColor ("Overlay Color", Color) = (1,1,1,1)
        _OverlayIntensity ("Overlay Intensity", Range(0,1)) = 0.0
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineSize ("Outline Thickness", Range(0,10)) = 1.0
        _OutlineSmoothness ("Outline Smoothness", Range(1,10)) = 2.0
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            Name "Universal2D"
            Tags { "LightMode"="Universal2D" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;

            float4 _Color;
            float _Intensity;
            float4 _OverlayColor;
            float _OverlayIntensity;
            float4 _OutlineColor;
            float _OutlineSize;
            float _OutlineSmoothness;

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            float SampleAlphaOutline(float2 uv)
            {
                float alpha = 0.0;
                float2 offset = _OutlineSize * _MainTex_TexelSize.xy;

                for (int y = -1; y <= 1; ++y)
                {
                    for (int x = -1; x <= 1; ++x)
                    {
                        if (x == 0 && y == 0) continue;
                        alpha += tex2D(_MainTex, uv + float2(x, y) * offset).a;
                    }
                }
                return alpha / 8.0;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 baseColor = tex2D(_MainTex, IN.uv);
                float centerAlpha = baseColor.a;
                float outlineAlpha = SampleAlphaOutline(IN.uv);

                // Smooth outline blend
                float smoothed = lerp(centerAlpha, outlineAlpha, _OutlineSmoothness);

                if (centerAlpha < smoothed)
                {
                    return _OutlineColor * smoothed;
                }

                // Tint base
                half4 tinted = lerp(baseColor, _Color, _Intensity * centerAlpha);
                half4 final = lerp(tinted, _OverlayColor, _OverlayIntensity * centerAlpha);
                return final;
            }
            ENDHLSL
        }
    }
}
