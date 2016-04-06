using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Negative")]
	public sealed class PP_Negative : PostProcessBase {
		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Negative");
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			Graphics.Blit(src, dest, base.material);
		}
	}

}