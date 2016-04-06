using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/ThermalVisionV1")]
	public sealed class PP_ThermalVisionV1 : PostProcessBase {
		//Variables//
		public float threshold = 0.5f;
		public Color color1 = Color.blue;
		public Color color2 = Color.yellow;
		public Color color3 = Color.red;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/ThermalVisionV1");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_Threshold", threshold);
			base.material.SetVector("_Color1", color1);
			base.material.SetVector("_Color2", color2);
			base.material.SetVector("_Color3", color3);
		}
	}

}