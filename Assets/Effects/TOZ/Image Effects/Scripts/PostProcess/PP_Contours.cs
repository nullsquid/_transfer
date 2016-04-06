using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Contours")]
	public sealed class PP_Contours : PostProcessBase {
		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Contours");
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			Graphics.Blit(src, dest, base.material);
		}
	}

}