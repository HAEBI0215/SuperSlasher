Shader "Custom/URP_AfterImage_Final"
{
    Properties
    {
        [HDR] _Color("Color", Color) = (1,1,1,1)
        _Alpha("Alpha", Range(0, 1)) = 1
        _RimLightMul("RimThickness", Range(0, 10)) = 1.0
        _RimLightPow("RimSoftness", Range(0, 10)) = 2.0
        _Intensity("Glow Intensity", Range(0, 20)) = 2.0
        
        [Header(Wave)]
        _Speed("Wave Speed", Float) = 3.0
        _Amplitude("Wave Amplitude", Float) = 2.0
        _Amount("Wave Amount", Float) = 0.05
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" "RenderPipeline" = "UniversalPipeline" }
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes {
                float4 positionOS : POSITION;
                float3 normalOS   : NORMAL;
            };

            struct Varyings {
                float4 positionCS : SV_POSITION;
                float3 viewDirWS  : TEXCOORD0;
                float3 normalWS   : TEXCOORD1;
            };

            float4 _Color;
            float _Alpha, _RimLightMul, _RimLightPow, _Intensity;
            float _Speed, _Amplitude, _Amount;

            Varyings vert(Attributes input)
            {
                Varyings output;
                // 흔들림 적용
                float wave = sin(_Time.y * _Speed + input.positionOS.y * _Amplitude) * _Amount;
                input.positionOS.x += wave;

                VertexPositionInputs posInputs = GetVertexPositionInputs(input.positionOS.xyz);
                output.positionCS = posInputs.positionCS;
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.viewDirWS = GetWorldSpaceViewDir(posInputs.positionWS);
                return output;
            }

            half4 frag(Varyings input) : SV_Target {
                float3 viewDir = normalize(input.viewDirWS);
                float3 normal = normalize(input.normalWS);
                
                // 외곽선 강조(Rim Light)
                float NdotV = saturate(dot(normal, viewDir));
                float rim = pow((1.0 - NdotV) * _RimLightMul, _RimLightPow);
                
                return half4(_Color.rgb * _Intensity, _Alpha * rim);
            }
            ENDHLSL
        }
    }
}