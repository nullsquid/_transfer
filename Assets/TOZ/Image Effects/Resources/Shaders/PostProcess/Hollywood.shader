Shader "Hidden/TOZ/ImageFX/Hollywood" {
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
			uniform float _LumThreshold;
			uniform float4x4 _MtxColor;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				main = mul(_MtxColor, main);
				main = max(main, fixed4(0.01, 0, 0, 1));
				half lum = main.y * (1.33 * (1 + (main.y + main.z) / main.x) - 1.68);
				fixed3 res = fixed3(0.62, 0.6, 1.0) * (lum * _LumThreshold);
				return fixed4(res.rgb, 1.0);
			}
			ENDCG
		}
	}

	Fallback off
}