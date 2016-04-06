Shader "Hidden/TOZ/ImageFX/BlurV" {
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
			uniform float _BlurStrength;
			static const float2 PK[10] =
			{
				{ 0, -5 }, { 0, -4 }, { 0, -3 }, { 0, -2 }, { 0, -1 },
				{ 0,  1 }, { 0,  2 }, { 0,  3 }, { 0,  4 }, { 0,  5 }
			};
			static const float BW[10] = 
			{
				0.008764, 0.026995, 0.064759, 0.120985, 0.176033,
				0.176033, 0.120985, 0.064759, 0.026995, 0.008764
			};

			v2f_img vert(appdata_img v) {
				v2f_img o;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(v2f_img i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv) * 0.199471;
				for(int j = 0; j < 10; j++)
					main.rgb += tex2D(_MainTex, i.uv + PK[j] * _BlurStrength / _ScreenParams.y).rgb * BW[j];
				return main;
			}
			ENDCG
		}
	}

	Fallback off
}