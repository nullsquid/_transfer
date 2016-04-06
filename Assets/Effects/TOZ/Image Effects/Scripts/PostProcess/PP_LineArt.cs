using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/LineArt")]
	public sealed class PP_LineArt : PostProcessBase {
		//Variables//
		public Color lineColor = Color.black;
		public float strength = 80f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/LineArt");
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