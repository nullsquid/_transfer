using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Tonemap")]
	public sealed class PP_Tonemap : PostProcessBase {
		//Variables//
		public float exposure = 0.1f;
		public float gamma = 1.0f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Tonemap");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_Exposure", exposure);
			base.material.SetFloat("_Gamma", gamma);
		}
	}

}