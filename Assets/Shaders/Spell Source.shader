Shader "Transparent/Spell Source" {
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
    #pragma surface surf SimpleLambert alpha
   
    half4 LightingSimpleLambert (SurfaceOutput s, half3 lightDir, half atten) {
              half NdotL = dot (s.Normal, lightDir);
              half4 c;
              c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten ) *0.5;
              c.a = s.Alpha;
              return c;
          }

    sampler2D _MainTex;
    sampler2D _BumpMap;
    fixed4 _Color;
   
    struct Input {
        float2 uv_MainTex;
        float2 uv_BumpMap;
    };
   
    void surf (Input IN, inout SurfaceOutput o) {
        fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		float dist = sqrt(pow(IN.uv_MainTex[0] - 0.5, 2) + pow(IN.uv_MainTex[1] - 0.5, 2));
        o.Albedo = c.rgb + (frac(dist - _Time[1]) * 0.5);
        o.Alpha = c.a * 2;
        // o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
    }
    ENDCG
    }   
	}
