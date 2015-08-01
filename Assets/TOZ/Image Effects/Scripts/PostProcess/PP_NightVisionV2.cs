using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/NightVisionV2")]
	public sealed class PP_NightVisionV2 : PostProcessBase {
		//Variables//
		public Texture2D NoiseTex;
		public Color visionColor = Color.green;
		public Color fadeColor = Color.black;
		public float noiseAmount = 1.0f;
		public float radius = 0.5f;
		public float fade = 0.2f;
		public float intensity = 0.5f;
		public float gamma = 2.2f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/NightVisionV2");
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
			base.material.SetVector("_VisionColor", visionColor);
			base.material.SetVector("_FadeColor", fadeColor);
			base.material.SetFloat("_NoiseAmount", noiseAmount);
			base.material.SetFloat("_Radius", radius);
			base.material.SetFloat("_Fade", fade);
			base.material.SetFloat("_Intensity", intensity);
			base.material.SetFloat("_Gamma", gamma);
		}
	}

}