Shader "Custom/GlowingLine"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FarColor ("Far Color", Color) = (1,1,1,1)
        _CloseColor ("Close Color", Color) = (1,0.75,0.8,1)
        _GlowIntensity ("Glow Intensity", Range(0,10)) = 1.0
        _DistanceToTarget ("Distance To Target", Range(0,1)) = 1.0
        _WaveSpeed ("Wave Speed", Range(0,10)) = 1.0
        _WaveAmplitude ("Wave Amplitude", Range(0,0.1)) = 0.005
        _WaveFrequency ("Wave Frequency", Range(0,50)) = 10.0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100
        
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

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
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _FarColor;
            float4 _CloseColor;
            float _GlowIntensity;
            float _DistanceToTarget;
            float _WaveSpeed;
            float _WaveAmplitude;
            float _WaveFrequency;
            
            v2f vert (appdata v)
            {
                v2f o;
                // Add wavering to vertex position
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                float time = _Time.y * _WaveSpeed;
                
                // Create wave effect on vertex
                float wave = sin(worldPos.x * _WaveFrequency + time) * 
                           cos(worldPos.y * _WaveFrequency * 0.5 + time * 0.7);
                
                // Apply wave to vertex
                v.vertex.xy += wave * _WaveAmplitude;
                
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                o.worldPos = worldPos;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float time = _Time.y * _WaveSpeed;
                
                // Add noise-based distortion
                float noise = frac(sin(dot(i.worldPos.xy + time * 0.1, float2(12.9898, 78.233))) * 43758.5453);
                uv += (noise - 0.5) * _WaveAmplitude * 0.2;
                
                // Sample the texture
                fixed4 col = tex2D(_MainTex, uv);
                
                // Lerp between close and far colors based on distance
                fixed4 lerpedColor = lerp(_CloseColor, _FarColor, _DistanceToTarget);
                
                // Apply glow effect
                float glow = col.a * _GlowIntensity;
                
                // Add wave-based glow variation
                float waveGlow = sin(i.worldPos.x * _WaveFrequency * 0.5 + time) * 
                               cos(i.worldPos.y * _WaveFrequency * 0.3 + time * 0.7);
                glow *= (1.0 + waveGlow * 0.2);
                
                // Combine colors
                fixed4 finalColor = lerpedColor * col * i.color;
                finalColor.rgb += glow * lerpedColor.rgb;
                
                return finalColor;
            }
            ENDCG
        }
    }
}