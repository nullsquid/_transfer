using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Displacement")]
	public sealed class PP_Displacement : PostProcessBase {
		//Variables//
		public Texture2D bumpTexture;
		public float amount = 0.5f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Displacement");
		}

		void Start() {
			if(bumpTexture != null)
				base.material.SetTexture("_BumpTex", bumpTexture);
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