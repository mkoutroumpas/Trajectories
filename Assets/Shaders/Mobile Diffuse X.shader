Shader "Mobile/Diffuse X" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color("Color",Color)=(0.5,0.5,0.5,1.0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
 
		LOD 150
		CGPROGRAM
		#pragma surface surf Lambert noforwardadd finalcolor:myColor
		sampler2D _MainTex;
		struct Input {
			float2 uv_MainTex;
		};
 
		fixed4 _Color;
		void myColor (Input IN, SurfaceOutput o, inout fixed4 color)
		{
			color *= _Color;
		}
		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}

	Fallback "Mobile/Diffuse"
}