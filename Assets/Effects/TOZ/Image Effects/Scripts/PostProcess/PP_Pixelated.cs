using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Pixelated")]
	public sealed class PP_Pixelated : PostProcessBase {
		//Variables//
		public int pixelWidth = 16;
		public int pixelHeight = 16;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Pixelated");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_PixWidth", pixelWidth);
			base.material.SetFloat("_PixHeight", pixelHeight);
		}
	}

}