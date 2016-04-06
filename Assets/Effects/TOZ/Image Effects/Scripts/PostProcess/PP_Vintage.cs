using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Vintage")]
	public sealed class PP_Vintage : PostProcessBase {
		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Vintage");
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			Graphics.Blit(src, dest, base.material);
		}
	}

}