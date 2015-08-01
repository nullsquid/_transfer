using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/SecurityCamera")]
	public sealed class PP_SecurityCamera : PostProcessBase {
		//Variables//
		public float speed = 2.0f;
		public float thickness = 3.0f;
		public float luminance = 0.5f;
		public float darkness = 0.75f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/SecurityCamera");
		}

		void Start() {
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_Speed", speed);
			base.material.SetFloat("_Thickness", thickness);
			base.material.SetFloat("_Luminance", luminance);
			base.material.SetFloat("_Darkness", darkness);
		}
	}

}