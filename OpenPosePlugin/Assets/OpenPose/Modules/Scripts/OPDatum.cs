// OpenPose Unity Plugin v1.0.0alpha-1.5.0
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenPose {
    /*
        Data struct for OP output
        Comments are from OpenPose
     */
    public struct OPDatum{
        public ulong id; /**< Datum ID. Internally used to sort the Datums if multi-threading is used. */
        public ulong subId; /**< Datum sub-ID. Internally used to sort the Datums if multi-threading is used. */
        public ulong subIdMax; /**< Datum maximum sub-ID. Used to sort the Datums if multi-threading is used. */

        /**
         * Name used when saving the data to disk (e.g. `write_images` or `write_keypoint` flags in the demo).
         */
        public string name;

        /**
         * Corresponding frame number.
         * If the producer (e.g., video) starts from frame 0 and does not repeat any frame, then frameNumber should
         * match the field id.
         */
        public ulong frameNumber;

        // --------------------------- Input image and rendered version parameters ---------------------------- //
        /**
         * Original image to be processed in cv::Mat uchar format.
         * Size: (input_width x input_height) x 3 channels (BGR)
         */
        public MultiArray<byte> cvInputData;

        // Other parameters not available

        // ------------------------------ Resulting Array<float> data parameters ------------------------------ //
        /**
         * Body pose (x,y,score) locations for each person in the image.
         * It has been resized to the desired output resolution (e.g. `resolution` flag in the demo).
         * Size: #people x #body parts (e.g. 18 for COCO or 15 for MPI) x 3 ((x,y) coordinates + score)
         */
        public MultiArray<float> poseKeypoints;

        /**
         * People ID
         * It returns a person ID for each body pose, providing temporal consistency. The ID will be the same one
         * for a person across frames. I.e. this ID allows to keep track of the same person in time.
         * If either person identification is disabled or poseKeypoints is empty, poseIds will also be empty.
         * Size: #people
         */
        public MultiArray<long> poseIds;

        /**
         * Body pose global confidence/score for each person in the image.
         * It does not only consider the score of each body keypoint, but also the score of each PAF association.
         * Optimized for COCO evaluation metric.
         * It will highly penalyze people with missing body parts (e.g. cropped people on the borders of the image).
         * If poseKeypoints is empty, poseScores will also be empty.
         * Size: #people
         */
        public MultiArray<float> poseScores;

        /**
         * Body pose heatmaps (body parts, background and/or PAFs) for the whole image.
         * This parameter is by default empty and disabled for performance. Each group (body parts, background and
         * PAFs) can be individually enabled.
         * #heatmaps = #body parts (if enabled) + 1 (if background enabled) + 2 x #PAFs (if enabled). Each PAF has 2
         * consecutive channels, one for x- and one for y-coordinates.
         * Order heatmaps: body parts + background (as appears in POSE_BODY_PART_MAPPING) + (x,y) channel of each PAF
         * (sorted as appears in POSE_BODY_PART_PAIRS). See `pose/poseParameters.hpp`.
         * The user can choose the heatmaps normalization: ranges [0, 1], [-1, 1] or [0, 255]. Check the
         * `heatmaps_scale` flag in {OpenPose_path}doc/demo_overview.md for more details.
         * Size: #heatmaps x output_net_height x output_net_width
         */
        public MultiArray<float> poseHeatMaps;

        /**
         * Body pose candidates for the whole image.
         * This parameter is by default empty and disabled for performance. It can be enabled with `candidates_body`.
         * Candidates refer to all the detected body parts, before being assembled into people. Note that the number
         * of candidates is equal or higher than the number of body parts after being assembled into people.
         * Size: #body parts x min(part candidates, POSE_MAX_PEOPLE) x 3 (x,y,score).
         * Rather than vector, it should ideally be:
         * std::array<std::vector<std::array<float,3>>, #BP> poseCandidates;
         */
        public List<List<Vector3>> poseCandidates; // Not supported yet

        /**
         * Face detection locations (x,y,width,height) for each person in the image.
         * It is resized to cvInputData.size().
         * Size: #people
         */
        public List<Rect> faceRectangles;

        /**
         * Face keypoints (x,y,score) locations for each person in the image.
         * It has been resized to the same resolution as `poseKeypoints`.
         * Size: #people x #face parts (70) x 3 ((x,y) coordinates + score)
         */
        public MultiArray<float> faceKeypoints;

        /**
         * Face pose heatmaps (face parts and/or background) for the whole image.
         * Analogous of bodyHeatMaps applied to face. However, there is no PAFs and the size is different.
         * Size: #people x #face parts (70) x output_net_height x output_net_width
         */
        public MultiArray<float> faceHeatMaps;

        /**
         * Hand detection locations (x,y,width,height) for each person in the image.
         * It is resized to cvInputData.size().
         * Size: #people
         */
        public List<Pair<Rect>> handRectangles;

        /**
         * Hand keypoints (x,y,score) locations for each person in the image.
         * It has been resized to the same resolution as `poseKeypoints`.
         * handKeypoints[0] corresponds to left hands, and handKeypoints[1] to right ones.
         * Size each Array: #people x #hand parts (21) x 3 ((x,y) coordinates + score)
         */
        public Pair<MultiArray<float>> handKeypoints;

        /**
         * Hand pose heatmaps (hand parts and/or background) for the whole image.
         * Analogous of faceHeatMaps applied to face.
         * Size each Array: #people x #hand parts (21) x output_net_height x output_net_width
         */
        public Pair<MultiArray<float>> handHeatMaps;

        // ---------------------------------------- 3-D Reconstruction parameters ---------------------------------------- //
        /**
         * Body pose (x,y,z,score) locations for each person in the image.
         * Size: #people x #body parts (e.g. 18 for COCO or 15 for MPI) x 4 ((x,y,z) coordinates + score)
         */
        public MultiArray<float> poseKeypoints3D; // Not supported yet

        /**
         * Face keypoints (x,y,z,score) locations for each person in the image.
         * It has been resized to the same resolution as `poseKeypoints3D`.
         * Size: #people x #face parts (70) x 4 ((x,y,z) coordinates + score)
         */
        public MultiArray<float> faceKeypoints3D; // Not supported yet

        /**
         * Hand keypoints (x,y,z,score) locations for each person in the image.
         * It has been resized to the same resolution as `poseKeypoints3D`.
         * handKeypoints[0] corresponds to left hands, and handKeypoints[1] to right ones.
         * Size each Array: #people x #hand parts (21) x 4 ((x,y,z) coordinates + score)
         */
        public Pair<MultiArray<float>> handKeypoints3D; // Not supported yet

        /**
         * 3x4 camera matrix of the camera (equivalent to cameraIntrinsics * cameraExtrinsics).
         */
        public Matrix4x4 cameraMatrix; // Not supported yet

        /**
         * 3x4 extrinsic parameters of the camera.
         */
        public Matrix4x4 cameraExtrinsics; // Not supported yet

        /**
         * 3x3 intrinsic parameters of the camera.
         */
        public Matrix4x4 cameraIntrinsics; // Not supported yet
    }

    // From OpenPose: std::array<2>
    public class Pair<T> : List<T>{
        // Constructors
        public Pair() : base(2){}
        public Pair(IEnumerable<T> collection) : base(collection){
            if (Count > 2) this.RemoveRange(2, Count - 2);
        }
        public Pair(T left, T right) : base(new List<T>(){left, right}){}
        private Pair(int capacity){}

        // Access the left element [0]
        public T left {
            get { return this[0]; }
            set { this[0] = value; }
        }

        // Access the right element [1]
        public T right {
            get { return this[1]; }
            set { this[1] = value; }
        }
    }

    // From OpenPose: op::Array
    public class MultiArray<T> : List<T>{
        // Constructors
        public MultiArray() : base(){ Resize(); }
        public MultiArray(params int[] sizes) : base(){ Resize(sizes); }
        public MultiArray(IEnumerable<T> collection, params int[] sizes) : base(collection){ Resize(sizes); }
        private MultiArray(int capacity){}
        private MultiArray(IEnumerable<T> collection){}

        private void Resize(params int[] sizes){
            this.sizes = new List<int>(sizes);
            if (sizes.Length == 0) volume = 0;
            else {
                volume = 1;
                foreach (var i in sizes){ volume *= i; }
            }
            Capacity = volume;
        }

        // Functions
        public T Get(params int[] idx){
            return this[GetIndex(idx)];
        }

        public List<int> GetSize(){
            return new List<int>(sizes);
        }
        public int GetSize(int layer){
            if (layer < 0 || layer >= sizes.Count) return 0;
            return sizes[layer];
        }

        public int GetNumberDimensions(){
            return sizes.Count;
        }

        public int GetVolume(){
            return volume;
        }

        public bool Empty(){
            return (volume == 0);
        }

        private int GetIndex(params int[] indexes){
            Debug.AssertFormat(indexes.Length == GetNumberDimensions(), "Wrong count of params");
            int index = 0;
            int accumulated = 1;
            for (int i = indexes.Length - 1; i >= 0; i--)
            {
                if (indexes[i] >= sizes[i]) {
                    Debug.LogError("Size overflow at dimension: " + i);
                    return -1;
                }
                index += accumulated * indexes[i];
                accumulated *= sizes[i];
            }
            return index;
        }

        // Members
        private List<int> sizes;
        private int volume;
    }
}
