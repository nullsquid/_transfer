using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Emboss")]
	public sealed class PP_Emboss : PostProcessBase {
		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Emboss");
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			Graphics.Blit(src, dest, base.material);
		}
	}

}