Shader "Hidden/TOZ/ImageFX/DreamBlur" {
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
			uniform float _Strength, _Desaturation;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				float2 dist = _MainTex_TexelSize.xy * _Strength;
				main.rgb += tex2D(_MainTex, i.uv + dist * 1.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv + dist * 2.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv + dist * 3.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv + dist * 4.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv + dist * 5.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv - dist * 1.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv - dist * 2.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv - dist * 3.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv - dist * 4.0).rgb;
				main.rgb += tex2D(_MainTex, i.uv - dist * 5.0).rgb;
				main.rgb /= 11;
				fixed lum = Luminance(main.rgb);
				fixed3 result = lerp(main.rgb, lum.xxx, _Desaturation);
				return fixed4(result, main.a);
			}
			ENDCG
		}
	}

	Fallback off
}