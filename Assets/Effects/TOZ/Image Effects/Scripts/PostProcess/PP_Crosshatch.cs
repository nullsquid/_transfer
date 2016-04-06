using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Crosshatch")]
	public sealed class PP_Crosshatch : PostProcessBase {
		//Variables//
		public Color lineColor = Color.white;
		public float strength = 0.01f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Crosshatch");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetVector("_LineColor", lineColor);
			base.material.SetFloat("_Strength", strength);
		}
	}

}