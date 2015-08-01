Shader "Hidden/TOZ/ImageFX/SecurityCamera" {
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
			uniform float _Speed;
			uniform float _Thickness;
			uniform float _Luminance;
			uniform float _Darkness;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				float cycle = sin((i.uv.y / _MainTex_TexelSize.y - _Time.y * _Speed) *_Thickness);
				main.rgb *= _Darkness + _Luminance * cycle;
				return main;
			}
			ENDCG
		}
	}

	Fallback off
}