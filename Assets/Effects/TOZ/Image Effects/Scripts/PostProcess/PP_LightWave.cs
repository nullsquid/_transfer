using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/LightWave")]
	public sealed class PP_LightWave : PostProcessBase {
		//Variables//
		public float red = 4f;
		public float green = 4f;
		public float blue = 4f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/LightWave");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_Red", red);
			base.material.SetFloat("_Green", green);
			base.material.SetFloat("_Blue", blue);
		}
	}

}