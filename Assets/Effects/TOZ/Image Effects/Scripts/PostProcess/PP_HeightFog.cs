using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/HeightFog")]
	public sealed class PP_HeightFog : PostProcessBase {
		//Variables//
		public float Density = 100.0f;
		public float Height = 0.0f;
		public float FallOff = 1.0f;
		public float Scale = 0.0025f;
		public float Speed = 0.005f;
		public Texture2D NoiseTex;
		public Color FogColor = Color.gray;
		private Camera cam;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/HeightFog");
			cam = GetComponent<Camera>();
			cam.depthTextureMode |= DepthTextureMode.Depth;
		}

		void Start() {
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
			base.material.SetVector("_Height", new Vector4(Height, 1.0f / FallOff));
			base.material.SetFloat("_Density", Density * 0.01f);
			base.material.SetTexture("_NoiseTex", NoiseTex);
			base.material.SetColor("_FogColor", FogColor);
			base.material.SetFloat("_Scale", Scale);
			base.material.SetFloat("_Speed", Speed);
		}
	}

}