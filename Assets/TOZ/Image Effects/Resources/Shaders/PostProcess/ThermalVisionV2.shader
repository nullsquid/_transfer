Shader "Hidden/TOZ/ImageFX/ThermalVisionV2" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
		_NoiseTex("Noise (RGB)", 2D) = "white" {}
		_ThermalTex("Thermal (RGB)", 2D) = "white" {}
	}

	CGINCLUDE
	#include "UnityCG.cginc"

	uniform sampler2D _CameraDepthNormalsTexture;
	uniform float4 _WS_CameraPosition;

	void GetPosAndNormals(float2 uvCoord, float4 ray, out float3 pos, out float3 norm) {
		float4 encoded = tex2D(_CameraDepthNormalsTexture, uvCoord);
		float d;
		float3 n;
		DecodeDepthNormal(encoded, d, n);
		//Norm
		norm = n;
		//Pos
		float depth = Linear01Depth(d);
		float4 wsDir = depth * ray;
		pos = _WS_CameraPosition.xyz + wsDir.xyz;
	}
	ENDCG

	SubShader {
		Pass {
			Name "BASE"
			Tags { "LightMode" = "Always" }

			ZTest Always Cull Off ZWrite Off Fog { Mode off }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_TexelSize;
			uniform float4x4 _WS_FrustumCorners;
			uniform sampler2D _NoiseTex, _ThermalTex;
			uniform float _NoiseAmount, _Gamma;

			struct v2f {
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv_depth : TEXCOORD1;
				float4 ray : TEXCOORD2;
			};

			v2f vert(appdata_img v) {
				v2f o;
				float index = v.vertex.z;
				v.vertex.z = 0.1;
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.texcoord.xy;
				o.uv_depth = v.texcoord.xy;
				#if UNITY_UV_STARTS_AT_TOP
				if(_MainTex_TexelSize.y < 0)
					o.uv.y = 1-o.uv.y;
				#endif
				o.ray = _WS_FrustumCorners[(int)index];
				o.ray.w = index;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target {
				fixed4 main = tex2D(_MainTex, i.uv);
				fixed lum = Luminance(main.rgb);
				float3 pos, norm;
				GetPosAndNormals(i.uv_depth, i.ray, pos, norm);

				fixed3 result = 0;
				float3 eyeVec = normalize(_WS_CameraPosition.xyz - pos);
				float rad = _Gamma;
				rad += dot(eyeVec, norm);
				float nuv = lum * saturate(rad);
				result = tex2D(_ThermalTex, float2(nuv, nuv)).rgb + tex2D(_NoiseTex, _NoiseAmount * (i.uv + sin(_Time.y * 50.0))).rgb;
				return fixed4(result, main.a);
			}
			ENDCG
		}
	}

	Fallback off
}