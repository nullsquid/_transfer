using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Posterize")]
	public sealed class PP_Posterize : PostProcessBase {
		//Variables//
		public int colors = 4;
		public float gamma = 1f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Posterize");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetInt("_Colors", colors);
			base.material.SetFloat("_Gamma", gamma);
		}
	}

}