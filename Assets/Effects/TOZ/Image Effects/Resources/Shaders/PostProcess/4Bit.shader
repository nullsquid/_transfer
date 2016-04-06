Shader "Hidden/TOZ/ImageFX/4Bit" {
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
			uniform int _BitDepth;
			uniform float _Contrast;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				main.rgb = 0.5 + _Contrast * (main.rgb - 0.5);
				half bit = pow((int)_BitDepth, 2);
				int3 bitCol = (main.rgb + 1.0 / bit) * bit;
				return fixed4(bitCol.x/bit, bitCol.y/bit, bitCol.z/bit, main.a);
			}
			ENDCG
		}
	}

	Fallback off
}