Shader "Hidden/TOZ/ImageFX/FakeHDR" {
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
			uniform float _Amount;
			uniform float _Multiplier;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				fixed3 main2 = main.rgb;
				fixed lum = Luminance(main.rgb);
				half std = min(_Amount, (1.0 - _Amount));
				float score = (lum - _Amount) / std;
				main.rgb = (main.rgb * exp2(score)) - main.rgb;
				main *= _Multiplier;
				return fixed4(main.rgb + main2, main.a);
			}
			ENDCG
		}
	}

	Fallback off
}