Shader "Hidden/TOZ/ImageFX/SinCity" {
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
			uniform fixed4 _SelectedColor, _ReplacedColor;
			uniform float _Desaturation, _Tolerance;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				fixed3 lum = Luminance(main.rgb) * _Desaturation;
				fixed3 col = _SelectedColor.rgb;
				if(main.r < col.r + _Tolerance && main.r > col.r - _Tolerance &&
					main.g < col.g + _Tolerance && main.g > col.g - _Tolerance &&
					main.b < col.b + _Tolerance && main.b > col.b - _Tolerance)
					lum.rgb = _ReplacedColor.rgb;
				return fixed4(lum.rgb, main.a);
			}
			ENDCG
		}
	}

	Fallback off
}