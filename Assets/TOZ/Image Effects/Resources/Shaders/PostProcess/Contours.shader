Shader "Hidden/TOZ/ImageFX/Contours" {
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
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_TexelSize;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				half4 min = float4(1.0, 1.0, 1.0, 1);
				half4 max = float4(0.0, 0.0, 0.0, 1);

				for(int xRow = 0; xRow < 4; xRow++) {
					for(int yRow = 0; yRow < 4; yRow++) {
						fixed4 c = tex2D(_MainTex, i.uv + float2(xRow * _MainTex_TexelSize.x, yRow * _MainTex_TexelSize.y));
						c.rgb *= c.a;
						if(c.r < min.x) min.x = c.r;
						if(c.g < min.y) min.y = c.g;
						if(c.b < min.z) min.z = c.b;
						if(c.r > max.x) max.x = c.r;
						if(c.g > max.y) max.y = c.g;
						if(c.b > max.z) max.z = c.b;
					}
				}

				float f = (max.x - min.x) + (max.y - min.y) + (max.y - min.y);
				f = 1.0 - saturate(f);
				f = 0.5 + 1.0 * (f - 0.5);
				f = 1.0 - saturate(f);
				return fixed4(f, f, f, f);
			}
			ENDCG
		}
	}

	Fallback off
}