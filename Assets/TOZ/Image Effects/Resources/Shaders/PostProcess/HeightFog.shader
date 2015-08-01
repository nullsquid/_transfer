Shader "Hidden/TOZ/ImageFX/HeightFog" {
	Properties {
		_MainTex("Base (RGB)", 2D) = "white" {}
	}

	CGINCLUDE
	#include "UnityCG.cginc"

	uniform sampler2D _CameraDepthTexture;
	uniform float4 _WS_CameraPosition;

	float3 GetPositionFromDepth(float2 uvCoord, float4 ray) {
		float depth = Linear01Depth(tex2D(_CameraDepthTexture, uvCoord).r);
		float4 wsDir = depth * ray;
		return (_WS_CameraPosition + wsDir.xyz);
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
			uniform sampler2D _NoiseTex;
			uniform fixed4 _FogColor;
			uniform float _Density;
			uniform float4 _Height;
			uniform float _Scale;
			uniform float _Speed;

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
				float4 col = tex2D(_MainTex, i.uv);
				float3 pos = GetPositionFromDepth(i.uv_depth, i.ray);

				float3 fogPos = pos.xyz; fogPos.y = _Height.x;
				float3 eyeVec = _WS_CameraPosition.xyz - fogPos;
				float3 eyeVecNorm = normalize(eyeVec);
				float t = (_Height.x - _WS_CameraPosition.y) / eyeVecNorm.y;
				float3 surfacePoint = _WS_CameraPosition.xyz + eyeVecNorm * -abs(t);
				float noise = tex2D(_NoiseTex, surfacePoint.xz * _Scale + _Time.y * _Speed).r;

				float fog = max((_Height.x - pos.y) * _Height.y * noise, (pos.y - _Height.x) * _Height.y * noise);
				fog *= fog;
				fog = exp(-fog) * _Density;
				return lerp(col, _FogColor, fog);
				//return float4(pos, 1);
			}
			ENDCG
		}
	}

	Fallback off
}