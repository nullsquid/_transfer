using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Pulse")]
	public sealed class PP_Pulse : PostProcessBase {
		//Variables//
		public float directionX = 0.5f;
		public float directionY = 0.5f;
		public float speed = 5.0f;
		public float amplitude = 0.1f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Pulse");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_DirectionX", directionX);
			base.material.SetFloat("_DirectionY", directionY);
			base.material.SetFloat("_Speed", speed);
			base.material.SetFloat("_Amplitude", amplitude);
		}
	}

}