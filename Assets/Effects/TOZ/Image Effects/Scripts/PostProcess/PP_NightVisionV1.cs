using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/NightVisionV1")]
	public sealed class PP_NightVisionV1 : PostProcessBase {
		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/NightVisionV1");
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			Graphics.Blit(src, dest, base.material);
		}
	}

}