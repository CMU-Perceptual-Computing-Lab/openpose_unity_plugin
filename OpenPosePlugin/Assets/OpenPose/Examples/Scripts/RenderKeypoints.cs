// OpenPose Unity Plugin v1.0.0alpha-1.5.0
using UnityEngine;
using UnityEngine.UI;

namespace OpenPose.Example {
    /*
     * Visualize human data 2D for body, hand and face keypoints
     */
    [RequireComponent(typeof(LineRenderer))]
    public class RenderKeypoints : MonoBehaviour {

        // Bone ends
        public RectTransform Joint0, Joint1;

        private LineRenderer _lr;
        private LineRenderer lineRenderer { get { if (!_lr) _lr = GetComponent<LineRenderer>(); return _lr; } }

        // Update is called once per frame
        void Update() {
            if (Joint0 && Joint1) {
                lineRenderer.enabled = Joint0.gameObject.activeInHierarchy && Joint1.gameObject.activeInHierarchy;
                lineRenderer.SetPosition(0, Joint0.localPosition);
                lineRenderer.SetPosition(1, Joint1.localPosition);
            }
        }
    }
}
