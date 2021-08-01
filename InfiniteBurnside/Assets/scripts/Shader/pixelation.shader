Shader "Hidden/pixelation"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _screenWidth("Width", float) = 6400.0
        _screenHeight("Height", float) = 480.0
        _pixelX("X", float) = 2.0
        _pixelY("Y", float) = 2.0
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _screenWidth;
            float _screenHeight;
            float _pixelX;
            float _pixelY;
      

            fixed4 frag (v2f i) : SV_Target
            {
            /*
                fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                col.rgb = 1 - col.rgb;
                return col;
            */
                
                float2 uv = i.uv;
                float X = _screenWidth/_pixelX;
                float Y = _screenWidth/_pixelY;
                
                return tex2D(_MainTex, float2(floor(X * uv.x)/X, floor(Y * uv.y)/Y));
            }
            ENDCG
        }
    }
}
