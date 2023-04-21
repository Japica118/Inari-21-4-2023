Shader "Custom/WallTransparent" {
    Properties{
        _MainTex("Base Map", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _Cutoff("Alpha cutoff", Range(0,1)) = 0.5
        _FadeStartDistance("Fade Start Distance", Range(0, 100)) = 5
        _FadeEndDistance("Fade End Distance", Range(0, 100)) = 10
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float2 uv : TEXCOORD0;
                    UNITY_FOG_COORDS(1)
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Color;
                float _Cutoff;
                float _FadeStartDistance;
                float _FadeEndDistance;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    UNITY_TRANSFER_FOG(o,o.vertex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    // Calculate distance from camera to the vertex
                    float distance = length(UnityWorldSpaceViewDir(i.vertex));

                // Calculate the transparency based on the distance
                float transparency = 1.0 - (distance - _FadeStartDistance) / (_FadeEndDistance - _FadeStartDistance);
                transparency = saturate(transparency);

                // Sample the texture and multiply it by the material color
                fixed4 texColor = tex2D(_MainTex, i.uv) * _Color;

                // Set the alpha of the color based on the transparency
                texColor.a = transparency;

                // Cut off the pixel if the alpha is below the cutoff threshold
                clip(texColor.a - _Cutoff);

                return texColor;
            }
            ENDCG
        }
        }

            FallBack "Diffuse"
}

