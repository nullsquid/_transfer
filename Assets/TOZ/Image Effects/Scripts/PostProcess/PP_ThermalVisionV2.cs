using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/ThermalVisionV2")]
	public sealed class PP_ThermalVisionV2 : PostProcessBase {
		//Variables//
		public Texture2D ThermalTex;
		public Texture2D NoiseTex;
		public float noiseAmount = 1.0f;
		public float gamma = 2.2f;
		private Camera cam;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/ThermalVisionV2");
			cam = GetComponent<Camera>();
			cam.depthTextureMode |= DepthTextureMode.DepthNormals;
		}

		void Start() {
			if(NoiseTex != null)
				base.material.SetTexture("_NoiseTex", NoiseTex);
			if(ThermalTex != null)
				base.material.SetTexture("_ThermalTex", ThermalTex);
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			if(!enabled) {
				Graphics.Blit(src, dest);
				return;
			}
			//Screen space positions
			float camNear = cam.nearClipPlane;
			float camFar = cam.farClipPlane;
			float camFov = cam.fieldOfView;
			float camFovHalf = camFov * 0.5f;
			float camAspect = cam.aspect;
			Matrix4x4 corners = Matrix4x4.identity;

			Vector3 right = transform.right * camNear * Mathf.Tan(camFovHalf * Mathf.Deg2Rad) * camAspect;
			Vector3 top = transform.up * camNear * Mathf.Tan(camFovHalf * Mathf.Deg2Rad);
			//Set frustum corners
			Vector3 corner = (transform.forward * camNear - right + top); //topleft
			float camScale = corner.magnitude * camFar/camNear;
			corner.Normalize();
			corner *= camScale;
			corners.SetRow(0, corner);
			corner = (transform.forward * camNear + right + top); //topright
			corner.Normalize();
			corner *= camScale;
			corners.SetRow(1, corner);
			corner = (transform.forward * camNear + right - top); //bottomright
			corner.Normalize();
			corner *= camScale;
			corners.SetRow(2, corner);
			corner = (transform.forward * camNear - right - top); //bottomleft
			corner.Normalize();
			corner *= camScale;
			corners.SetRow(3, corner);
			base.material.SetMatrix("_WS_FrustumCorners", corners);
			//Faster according to Unity samples
			base.material.SetVector("_WS_CameraPosition", transform.position);

			ApplyVariables();
			//Graphics.Blit(src, dest, base.material);
			CustomGraphicsBlit(src, dest, base.material, 0);
		}

		static void CustomGraphicsBlit(RenderTexture source, RenderTexture dest, Material mat, int pass) {
			RenderTexture.active = dest;
			mat.SetTexture("_MainTex", source);
			//Custom Quad
			GL.PushMatrix();
			GL.LoadOrtho();
			mat.SetPass(pass);
			GL.Begin(GL.QUADS);
			GL.MultiTexCoord2(0, 0.0f, 0.0f);
			GL.Vertex3(0.0f, 0.0f, 3.0f); //BL

			GL.MultiTexCoord2(0, 1.0f, 0.0f);
			GL.Vertex3(1.0f, 0.0f, 2.0f); //BR

			GL.MultiTexCoord2(0, 1.0f, 1.0f);
			GL.Vertex3(1.0f, 1.0f, 1.0f); //TR

			GL.MultiTexCoord2(0, 0.0f, 1.0f);
			GL.Vertex3(0.0f, 1.0f, 0.0f); //TL
			GL.End();
			GL.PopMatrix();
		}

		void ApplyVariables() {
			base.material.SetFloat("_NoiseAmount", noiseAmount);
			base.material.SetFloat("_Gamma", gamma);
		}
	}

}