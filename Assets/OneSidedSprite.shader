Shader "Custom/OneSidedSprite"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
            }

            Cull Back
            Lighting Off
            ZWrite Off
            Blend One OneMinusSrcAlpha

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 texcoord : TEXCOORD0;
                    fixed4 color : COLOR;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    fixed4 color : COLOR;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                fixed4 _Color;
                fixed4 _RendererColor;
                float4 _Flip;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    float4 pos = v.vertex;

                    // Apply flipping
                    pos.xy *= _Flip.xy;

                    o.vertex = UnityObjectToClipPos(pos);

                    #if defined(PIXELSNAP_ON)
                    o.vertex = UnityPixelSnap(o.vertex);
                    #endif

                    o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                    o.color = v.color * _Color * _RendererColor;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 texColor = tex2D(_MainTex, i.uv);
                    return texColor * i.color;
                }
                ENDCG
            }
        }

            Fallback "Transparent/VertexLit"
}
