Shader "Hidden/TOZ/ImageFX/Displacement" {
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
			uniform sampler2D _BumpTex;
			uniform float _Amount;

			struct v2f {
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
			};

			v2f vert(appdata_img v) {
				v2f o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				o.uv1 = v.texcoord.xy;
				#if UNITY_UV_STARTS_AT_TOP
				if(_MainTex_TexelSize.y < 0)
					o.uv1.y = 1-o.uv1.y;
				#endif
				return o;
			}

			fixed4 frag(v2f i) : SV_Target {
				fixed2 bump = (tex2D(_BumpTex, i.uv1).xy - 0.5) * _Amount;
				fixed4 main = tex2D(_MainTex, i.uv + bump);
				return main;
			}
			ENDCG
		}
	}

	Fallback off
}