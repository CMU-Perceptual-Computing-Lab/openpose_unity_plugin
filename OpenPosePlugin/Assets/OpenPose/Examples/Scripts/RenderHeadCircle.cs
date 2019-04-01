// OpenPose Unity Plugin v1.0.0alpha-1.5.0
using UnityEngine;
using UnityEngine.UI;

namespace OpenPose.Example {
    /*
     * Visualize face/head circle according to situations (for better looking):
     * If face is disabled, draw simple circle on nose
     * If face is enabled && keypoints detected >= 20, draw circle according to the kepoints rect
     * If face is enabled && keypoints detected < 20, draw circle according to the FaceRectangle output
     */
     [RequireComponent(typeof(Image))]
    public class RenderHeadCircle : MonoBehaviour {

		// Face center joint (nose)
		[SerializeField] RectTransform faceCenter;

		// Parent of face keypoints
		[SerializeField] Transform keypointsParent;

		// Face rectangle
		[SerializeField] RectTransform faceRect;
		
        private RectTransform rectTransform { get { return transform as RectTransform; } }
        private Image image { get { return GetComponent<Image>(); } }

		private bool findKeypointsRect(RectTransform[] keypoints, out Rect rect){
            bool res = false;
            float xMin = float.PositiveInfinity, yMin = float.PositiveInfinity;
            float xMax = float.NegativeInfinity, yMax = float.NegativeInfinity;
            foreach (var t in keypoints){
                if (t == keypointsParent) continue;
                res = true;
                if (t.localPosition.x < xMin) {
                    xMin = t.localPosition.x;
                }
                if (t.localPosition.x > xMax) {
                    xMax = t.localPosition.x;
                }
                if (t.localPosition.y < yMin) {
                    yMin = t.localPosition.y;
                }
                if (t.localPosition.y > yMax) {
                    yMax = t.localPosition.y;
                }
            }
            rect = new Rect();
            rect.xMin = xMin; rect.xMax = xMax;
            rect.yMin = yMin; rect.yMax = yMax;
            return res;
		}
		
		// Update is called once per frame
		void Update () {
			if (keypointsParent){
                // Face enabled,
                if (keypointsParent.gameObject.activeSelf){
                    var childList = keypointsParent.GetComponentsInChildren<RectTransform>(false);
                    // If >= 20 keypoints detected, draw face using keypoints rect.
                    if (childList.Length >= 20){
                        Rect rect;
                        if (findKeypointsRect(childList, out rect)) {
                            image.enabled = true;
                            rectTransform.localPosition = rect.center;
                            rectTransform.sizeDelta = rect.size * 1.5f;
                        }
                    }
                    // Less than 20 keypoints detected, draw face using faceRectangle
                    else {
                        if (faceRect){
                            if (faceRect.gameObject.activeInHierarchy) {
                                image.enabled = true;
                                rectTransform.localPosition = faceRect.localPosition;
                                rectTransform.sizeDelta = faceRect.sizeDelta * 0.8f;
                            } else {
                                image.enabled = false;
                            }
                        }
                    }
                }
                // Face disabled, draw face using center joint (nose)
                else {
                    if (faceCenter) {
                        image.enabled = faceCenter.gameObject.activeInHierarchy;
                        rectTransform.sizeDelta = Vector2.one * 150f;
                        rectTransform.localPosition = faceCenter.localPosition;
                    }
                }
            }
		}
	}
}
