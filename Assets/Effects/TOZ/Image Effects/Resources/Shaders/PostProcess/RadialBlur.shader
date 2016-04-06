Shader "Hidden/TOZ/ImageFX/RadialBlur" {
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
			uniform float _CenterX, _CenterY;
			uniform float _Strength;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				half2 center = float2(_CenterX, _CenterY);
				i.uv -= center;
				for(int j = 1; j < 11; j++) {
					float scale = 1.0 + (-_Strength * j / 10.0);
					main.rgb += tex2D(_MainTex, i.uv * scale + center);
				}
				main.rgb /= 10;
				return main;
			}
			ENDCG
		}
	}

	Fallback off
}