Shader "Hidden/TOZ/ImageFX/Crosshatch" {
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
			uniform fixed4 _LineColor;
			uniform float _Strength;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				fixed lum = Luminance(main.rgb);
				fixed3 res = _LineColor.rgb;
				if(lum < 1.00) {
					if(fmod(i.uv.x + i.uv.y, _Strength * 2) < _Strength)
						res = fixed3(0.0, 0.0, 0.0);
				}
				if(lum < 0.75) {
					if(fmod(i.uv.x + i.uv.y, _Strength * 2) < _Strength)
						res = fixed3(0.0, 0.0, 0.0);
				}
				if(lum < 0.50) {
					if(fmod(i.uv.x + i.uv.y - _Strength, _Strength) < _Strength)
						res = fixed3(0.0, 0.0, 0.0);
				}
				if(lum < 0.25) {
					if(fmod(i.uv.x + i.uv.y - _Strength, _Strength) < _Strength)
						res = fixed3(0.0, 0.0, 0.0);
				}
				return fixed4(res, main.a);
			}
			ENDCG
		}
	}

	Fallback off
}