Shader "Hidden/TOZ/ImageFX/RadialUndistortion" {
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
			uniform float _F;
			uniform float _OX;
			uniform float _OY;
			uniform float _K1;
			uniform float _K2;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				float2 xy = (i.uv - float2(_OX, _OY) / _ScreenParams.xy) / float2(_F, _F);
				float r = sqrt(dot(xy, xy));
				float r2 = r * r;
				float r4 = r2 * r2;
				float coeff = (_K1 * r2 + _K2 * r4);
				
				xy = ((xy + xy * coeff.xx) * _F.xx) + float2(_OX, _OY) / _ScreenParams.xy;
				fixed4 main = tex2D(_MainTex, xy);
				return main;
			}
			ENDCG
		}
	}

	Fallback off
}