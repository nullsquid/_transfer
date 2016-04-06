using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/SinCity")]
	public sealed class PP_SinCity : PostProcessBase {
		//Variables//
		public Color selectedColor = Color.red;
		public Color replacementColor = Color.white;
		public float desaturation = 0.5f;
		public float tolerance = 0.5f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/SinCity");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetColor("_SelectedColor", selectedColor);
			base.material.SetColor("_ReplacedColor", replacementColor);
			base.material.SetFloat("_Desaturation", desaturation);
			base.material.SetFloat("_Tolerance", tolerance);
		}
	}

}