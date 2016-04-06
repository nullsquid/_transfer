Shader "Hidden/TOZ/ImageFX/Bleach" {
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
			uniform float _Opacity;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				fixed lum = Luminance(main.rgb);
				fixed blend = lum.rrr;
				float L = min(1, max(0, 10 * (lum - 0.45)));
				half3 res1 = 2.0 * main.rgb * blend;
				half3 res2 = 1.0 - 2.0 * (1.0 - blend) * (1.0 - main.rgb);
				fixed3 newCol = lerp(res1, res2, L);
				fixed alpha = _Opacity * main.a;
				fixed3 mixRGB = alpha * newCol.rgb;
				mixRGB += ((1.0 - alpha) * main.rgb);
				return fixed4(mixRGB, main.a);
			}
			ENDCG
		}
	}

	Fallback off
}