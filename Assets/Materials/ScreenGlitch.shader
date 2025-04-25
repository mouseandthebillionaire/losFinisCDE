Shader "Custom/ScreenGlitch"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GlitchIntensity ("Glitch Intensity", Range(0, 1)) = 1
        _ChromaticAberration ("Chromatic Aberration", Range(0, 0.1)) = 0.02
        _BlockSize ("Block Size", Range(2, 50)) = 10
        _TimeScale ("Time Scale", Range(0, 10)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
            float _GlitchIntensity;
            float _ChromaticAberration;
            float _BlockSize;
            float _TimeScale;
            
            // Random function
            float rand(float2 co)
            {
                return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float time = _Time.y * _TimeScale;
                
                // Block glitch effect
                float2 block = floor(uv * _BlockSize);
                float noise = rand(block + time);
                
                // Apply horizontal glitch based on intensity
                float glitchOffset = (noise - 0.5) * 0.1 * _GlitchIntensity;
                uv.x += glitchOffset;
                
                // Vertical shake
                float shake = sin(time * 50) * 0.002 * _GlitchIntensity;
                uv.y += shake;
                
                // Chromatic aberration
                float ca = _ChromaticAberration * _GlitchIntensity;
                fixed4 r = tex2D(_MainTex, uv + float2(ca, 0));
                fixed4 g = tex2D(_MainTex, uv);
                fixed4 b = tex2D(_MainTex, uv - float2(ca, 0));
                
                // Random color shift
                float colorShift = noise * _GlitchIntensity * 0.1;
                
                fixed4 col = fixed4(r.r + colorShift, g.g, b.b + colorShift, 1);
                
                // Add scan lines
                float scanLine = sin(uv.y * 400 + time * 10) * 0.1 * _GlitchIntensity;
                col.rgb += scanLine;
                
                return col;
            }
            ENDCG
        }
    }
} 