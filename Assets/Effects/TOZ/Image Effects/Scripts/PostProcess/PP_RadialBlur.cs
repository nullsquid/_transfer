using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/RadialBlur")]
	public sealed class PP_RadialBlur : PostProcessBase {
		//Variables//
		public float centerX = 0.5f;
		public float centerY = 0.5f;
		public float strength = 1f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/RadialBlur");
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
			base.material.SetFloat("_Strength", strength);
		}
	}

}