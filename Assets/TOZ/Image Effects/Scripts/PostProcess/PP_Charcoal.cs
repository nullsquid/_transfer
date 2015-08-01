using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Charcoal")]
	public sealed class PP_Charcoal : PostProcessBase {
		//Variables//
		public Color lineColor = Color.black;
		public float strength = 1f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Charcoal");
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