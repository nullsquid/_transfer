using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/FakeHDR")]
	public sealed class PP_FakeHDR : PostProcessBase {
		//Variables//
		public float amount = 0.5f;
		public float multiplier = 1f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/FakeHDR");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_Amount", amount);
			base.material.SetFloat("_Multiplier", multiplier);
		}
	}

}