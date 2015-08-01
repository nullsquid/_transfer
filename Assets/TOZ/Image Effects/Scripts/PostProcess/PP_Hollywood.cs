using System;
using UnityEngine;

namespace TOZ.ImageEffects {

	[ExecuteInEditMode]
	[AddComponentMenu("Image Effects/TOZ/Hollywood")]
	public sealed class PP_Hollywood : PostProcessBase {
		//Variables//
		public float lumThreshold = 0.13f;

		//Mono Methods//
		void Awake() {
			base.shader = Shader.Find("Hidden/TOZ/ImageFX/Hollywood");
		}

		void Start() {
			Matrix4x4 mtx = Matrix4x4.zero;
			mtx.m00 = 0.5149f; mtx.m01 = 0.3244f; mtx.m02 = 0.1607f; mtx.m03 = 0.0f;
			mtx.m10 = 0.2654f; mtx.m11 = 0.6704f; mtx.m12 = 0.0642f; mtx.m13 = 0.0f;
			mtx.m20 = 0.0248f; mtx.m21 = 0.1248f; mtx.m22 = 0.8504f; mtx.m23 = 0.0f;
			mtx.m30 = 0.0000f; mtx.m31 = 0.0000f; mtx.m32 = 0.0000f; mtx.m33 = 0.0f;
			base.material.SetMatrix("_MtxColor", mtx);
			ApplyVariables();
		}

		void OnRenderImage(RenderTexture src, RenderTexture dest) {
			ApplyVariables();
			Graphics.Blit(src, dest, base.material);
		}

		void ApplyVariables() {
			base.material.SetFloat("_LumThreshold", lumThreshold);
		}
	}

}