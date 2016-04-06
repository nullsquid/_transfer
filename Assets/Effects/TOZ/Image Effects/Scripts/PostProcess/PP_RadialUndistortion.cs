using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/RadialUndistortion")]
	public sealed class PP_RadialUndistortion : PostProcessBase {
		//Variables//
		public float centerX = 320f;
		public float centerY = 240f;
		public float f = 0.9f;
		public float k1 = -0.27f;
		public float k2 = 0.08f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/RadialUndistortion");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_F", f);
			base.material.SetFloat("_OX", centerX);
			base.material.SetFloat("_OY", centerY);
			base.material.SetFloat("_K1", k1);
			base.material.SetFloat("_K2", k2);
		}
	}

}