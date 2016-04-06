Shader "Hidden/TOZ/ImageFX/Pulse" {
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
			uniform float _DirectionX, _DirectionY;
			uniform float _Speed;
			uniform float _Amplitude;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				float2 center = float2(_DirectionX, _DirectionY);
				i.uv -= center;
				i.uv *= 1.0 - (sin(_Time.y * _Speed) * _Amplitude + _Amplitude) * 0.5;
				i.uv += center;
				return tex2D(_MainTex, i.uv);
			}
			ENDCG
		}
	}

	Fallback off
}