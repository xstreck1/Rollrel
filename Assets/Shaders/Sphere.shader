Shader "Transparent/Sphere" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Texture", 2D) = "white" {}
    _BumpMap ("Bumpmap", 2D) = "white" {}
}
 
SubShader
{
    Ztest NotEqual
    Tags {"Queue"="Transparent +1" "IgnoreProjector"="True" "RenderType"="Transparent"}
    LOD 200
 
    CGPROGRAM
    #pragma surface surf Lambert alpha
   
    sampler2D _MainTex;
    sampler2D _BumpMap;
    fixed4 _Color;
   
    struct Input {
        float2 uv_MainTex;
        float2 uv_BumpMap;
    };
   
    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
        o.Albedo = c.rgb*2  + abs(0.5 - frac(_Time[1]));
        o.Alpha = c.a;
        // o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
    }
    ENDCG
    }
   
    Fallback "Transparent/VertexLit"
}