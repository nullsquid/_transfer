using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/4Bit")]
	public sealed class PP_4Bit : PostProcessBase {
		//Variables//
		public int bitDepth = 2;
		public float contrast = 1f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/4Bit");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetInt("_BitDepth", bitDepth);
			base.material.SetFloat("_Contrast", contrast);
		}
	}

}