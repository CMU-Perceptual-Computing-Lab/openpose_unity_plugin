// OpenPose Unity Plugin v1.0.0alpha-1.5.0
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace OpenPose.Example
{
    /*
	 * ImageRenderer renders the pure cvInputData to Texture2D
	 * The texture is used as background image
	 */
    public class ImageRenderer : MonoBehaviour {

		// Initial size of screen, default (1280, 720)
		[SerializeField] Vector2Int screenSize;

		// Texture to be rendered in image
		private Texture2D texture;

		private RectTransform rectTransform { get { return GetComponent<RectTransform>(); } }
		private RawImage image { get { return GetComponent<RawImage>(); } }

		public void UpdateImage(MultiArray<byte> data){
			// data size: width * height * 3 (BGR)
			if (data == null || data.Empty()) return;
			int height = data.GetSize(0), width = data.GetSize(1);
			
			/* TRICK */
			// Unity does not support BGR24 yet, which is the color format in OpenCV.
			// Here we are using RGB24 as data format, then swap R and B in shader, to maintain the performance.
			rectTransform.sizeDelta = new Vector2Int(width, height);
			texture.Resize(width, height, TextureFormat.RGB24, false);
			texture.LoadRawTextureData(data.ToArray());
			texture.Apply();			
		}

		// Visual effect for image
		public void FadeInOut(bool renderImage, float duration = 0.5f){
			if (renderImage) StartCoroutine(FadeCoroutine(Color.white, duration));
			else StartCoroutine(FadeCoroutine(Color.clear, duration));
		}
		private IEnumerator FadeCoroutine(Color goal, float duration){
			Color current = image.color;
			float t = 0f;
			while (t < duration){
				image.color = Color.Lerp(current, goal, t / duration);
				t += Time.deltaTime;
				yield return null;
			}
			image.color = goal;
		}

		// Use this for initialization
		void Start () {
			texture = new Texture2D(screenSize.x, screenSize.y);
			image.texture = texture;
		}
	}
}
