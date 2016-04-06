using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/LightShafts")]
	public sealed class PP_LightShafts : PostProcessBase {
		//Variables//
		public Transform lightSource;
		public float density = 0.4f;
		public float weight = 0.2f;
		public float decay = 0.9f;
		public float exposure = 0.5f;
		private Vector3 lightPos;
		private Camera cam;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/LightShafts");
		}

		void Start() {
			cam = GetComponent<Camera>();
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			lightPos = cam.WorldToViewportPoint(lightSource.position);
			if (lightPos.x < 0f || lightPos.x > 1f || lightPos.y < 0f || lightPos.y > 1f || lightPos.z < 0f) {
				base.material.SetVector("_LightPos", new Vector3(0.5f, 0.5f, 0f));
				base.material.SetFloat("_Density", density - density + 0.1f);
				base.material.SetFloat("_Weight", weight);
				base.material.SetFloat("_Decay", decay);
				base.material.SetFloat("_Exposure", exposure);
			}
			else {
				base.material.SetVector("_LightPos", lightPos);
				base.material.SetFloat("_Density", density);
				base.material.SetFloat("_Weight", weight);
				base.material.SetFloat("_Decay", decay);
				base.material.SetFloat("_Exposure", exposure);
			}
		}
	}

}