using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/DreamBlur")]
	public sealed class PP_DreamBlur : PostProcessBase {
		//Variables//
		public float desaturation = 1.0f;
		public float strength = 1f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/DreamBlur");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_Strength", strength);
			base.material.SetFloat("_Desaturation", desaturation);
		}
	}

}