Shader "Hidden/TOZ/ImageFX/Frost" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_NoiseTex("Noise (RGB)", 2D) = "white" {}
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

			uniform sampler2D _MainTex, _NoiseTex;
			uniform float4 _MainTex_TexelSize;
			uniform float _Amount;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 c0 = tex2D(_MainTex, i.uv - _MainTex_TexelSize.xy);
				fixed4 c1 = tex2D(_MainTex, i.uv + _MainTex_TexelSize.xy);
				fixed n = tex2D(_NoiseTex, i.uv * _Amount);
				n = fmod(n, 0.111111) / 0.111111;
				return lerp(c0, c1, n);
			}
			ENDCG
		}
	}

	Fallback off
}