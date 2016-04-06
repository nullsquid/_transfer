using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/FakeSSAO")]
	public sealed class PP_FakeSSAO : PostProcessBase {
		//Variables//
		public int amount = 4;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/FakeSSAO");
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
		}
	}

}