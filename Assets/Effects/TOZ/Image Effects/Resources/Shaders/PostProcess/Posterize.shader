Shader "Hidden/TOZ/ImageFX/Posterize" {
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
			uniform int _Colors;
			uniform float _Gamma;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				main.rgb = pow(main.rgb, _Gamma) * _Colors;
				main.rgb = floor(main.rgb) / _Colors;
				main.rgb = pow(main.rgb, 1.0 / _Gamma);
				return main;
			}
			ENDCG
		}
	}

	Fallback off
}