Shader "Hidden/TOZ/ImageFX/SphericalV1" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
	}

	SubShader {
		Pass {
			Name "BASE"
			Tags { "LightMode" = "Always" }

			ZTest Always Cull Off ZWrite Off Fog { Mode off }

			CGPROGRAM
			#include "UnityCG.cginc"
			#pragma vertex vert
			#pragma fragment frag

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_TexelSize;
			uniform float _Radius;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				float2 p = i.uv * 2.0 - 1.0;
				float rad = dot(p, p) * _Radius;
				float f = sqrt(1.0 - rad * rad);
				float2 nuv;
				nuv.x = (p.x * (f / 2.0)) + 0.5;
				nuv.y = (p.y * f) + 0.5;
				fixed4 main = tex2D(_MainTex, nuv);
				return main;
			}
			ENDCG
		}
	}

	Fallback off
}