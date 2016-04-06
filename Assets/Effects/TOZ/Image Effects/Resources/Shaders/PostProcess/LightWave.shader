Shader "Hidden/TOZ/ImageFX/LightWave" {
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
			uniform float _Red, _Green, _Blue;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 result = 0;
				result.r = tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x * _Red, 0)).r;
				result.g = tex2D(_MainTex, i.uv + float2(0, _MainTex_TexelSize.y * _Green)).r;
				result.b = tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x * _Blue, _MainTex_TexelSize.y * _Blue)).r;
				result.a = 1.0;
				return result;
			}
			ENDCG
		}
	}

	Fallback off
}