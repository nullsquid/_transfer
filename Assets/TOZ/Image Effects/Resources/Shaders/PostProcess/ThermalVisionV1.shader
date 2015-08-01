Shader "Hidden/TOZ/ImageFX/ThermalVisionV1" {
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
			uniform float4 _Color1, _Color2, _Color3;
			uniform float _Threshold;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				fixed lum = Luminance(main.rgb);
				int ix = (lum < _Threshold) ? 0 : 1;
				half lum2 = (lum - fixed(ix) * 0.5) / 0.5;
				fixed4 result = 0;
				if (ix == 0) {
					result = _Color1 * lum2 + _Color2 * (1.0 - lum2);
				}
				if (ix == 1) {
					result = _Color2 * lum2 + _Color3 * (1.0 - lum2);
				}
				return result;
			}
			ENDCG
		}
	}

	Fallback off
}