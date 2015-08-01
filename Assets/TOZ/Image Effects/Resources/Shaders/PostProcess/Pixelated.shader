Shader "Hidden/TOZ/ImageFX/Pixelated" {
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
			uniform float _PixWidth, _PixHeight;

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				float dx = _PixWidth * (_MainTex_TexelSize.x);
				float dy = _PixHeight * (_MainTex_TexelSize.y);
				float2 uv = float2(dx * floor((i.uv.x / dx)), dy * floor((i.uv.y / dy)));
				fixed4 main = tex2D(_MainTex, uv);
				return main;
			}
			ENDCG
		}
	}

	Fallback off
}