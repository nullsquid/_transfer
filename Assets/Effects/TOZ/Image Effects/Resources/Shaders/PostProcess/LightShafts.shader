Shader "Hidden/TOZ/ImageFX/LightShafts" {
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
			uniform float _Density;
			uniform float _Weight;
			uniform float _Decay;
			uniform float _Exposure;
			uniform float4 _LightPos;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				float2 duv = (i.uv - _LightPos.xy);
				duv *= 1.0f / 32 * _Density;
				half illum = 1.0f;
				for (int a = 0; a < 32; a++) {
					i.uv -= duv;
					fixed3 sample = tex2D(_MainTex, i.uv).rgb;
					sample *= illum * _Weight;
					main.rgb += sample;
					illum *= _Decay;
				}
				return fixed4(main.rgb * _Exposure, main.a);
			}
			ENDCG
		}
	}

	Fallback off
}