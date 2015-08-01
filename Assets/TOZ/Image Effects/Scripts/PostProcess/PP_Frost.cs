using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Frost")]
	public sealed class PP_Frost : PostProcessBase {
		//Variables//
		public Texture2D NoiseTex;
		public float amount = 1.0f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Frost");
		}

		void Start() {
			if(NoiseTex != null)
				base.material.SetTexture("_NoiseTex", NoiseTex);
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