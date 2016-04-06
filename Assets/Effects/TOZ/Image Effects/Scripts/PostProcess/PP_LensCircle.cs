using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/LensCircle")]
	public sealed class PP_LensCircle : PostProcessBase {
		//Variables//
		public float centerX = 0.5f;
		public float centerY = 0.5f;
		public float radiusX = 1.0f;
		public float radiusY = 0.0f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/LensCircle");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_CenterX", centerX);
			base.material.SetFloat("_CenterY", centerY);
			base.material.SetFloat("_RadiusX", radiusX);
			base.material.SetFloat("_RadiusY", radiusY);
		}
	}

}