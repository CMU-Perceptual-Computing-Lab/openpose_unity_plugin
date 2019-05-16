// OpenPose Unity Plugin v1.0.0alpha-1.5.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenPose {

    public enum OPState : byte {
        None,               // Default value, not used
        Ready,              // OP not yet started and ready to start
        Running,            // OP is running (or starting)
        Stopping            // OP received stop signal but not fully stopped
    }

    // Output type for output callback
	public enum OutputType : byte {
		None,               // Default value, also use as end of frame signal
		DatumsInfo,         // Includes: id, subId, subIdMax, frameNumber
        Name,
		PoseKeypoints,
		PoseIds,
		PoseScores,
		PoseHeatMaps,
		PoseCandidates,
		FaceRectangles,
		FaceKeypoints,
		FaceHeatMaps,
		HandRectangles,
		HandKeypoints,
		HandHeightMaps,
		PoseKeypoints3D,
		FaceKeypoints3D,
		HandKeypoints3D,
		CameraMatrix,
		CameraExtrinsics,
		CameraIntrinsics,
        Image
	}

    // From OpenPose: op::Priority
    public enum Priority : byte {
        None = 0,
        Low = 1,
        Normal = 2,
        High = 3,
        Max = 4,
        NoOutput = 255,
    }
    // From OpenPose: op::PoseMode
    public enum PoseMode : byte {
        Disabled = 0,
        Enabled,
        NoNetwork,
        Size,
    }
    // From OpenPose: op::Detector
    public enum Detector : byte {
        Body = 0,
        OpenCV,
        Provided,
        BodyWithTracking,
        Size,
    }
    // From OpenPose: op::ProducerType
	public enum ProducerType : byte {
        /** Stereo FLIR (Point-Grey) camera reader. Based on Spinnaker SDK. */
        FlirCamera,
        /** An image directory reader. It is able to read images on a folder with a interface similar to the OpenCV
         * cv::VideoCapture.
         */
        ImageDirectory,
        /** An IP camera frames extractor, extending the functionality of cv::VideoCapture. */
        IPCamera,
        /** A video frames extractor, extending the functionality of cv::VideoCapture. */
        Video,
        /** A webcam frames extractor, extending the functionality of cv::VideoCapture. */
        Webcam,
        /** No type defined. Default state when no specific Producer has been picked yet. */
        None,
    }
    // From OpenPose: op::ScaleMode
    public enum ScaleMode : byte {
        InputResolution,
        NetOutputResolution,
        OutputResolution,
        ZeroToOne, // [0, 1]
        PlusMinusOne, // [-1, 1]
        UnsignedChar, // [0, 255]
        NoScale,
    }
    // From OpenPose: op::HeatMapType // This one is DIFFERENT
    public enum HeatMapType : byte {
		None = 0,
        Parts = 1 << 0,
        Background = 1 << 1,
        PAFs = 1 << 2,
		All = Parts | Background | PAFs
    }
	// From OpenPose: op::RenderMode
    public enum RenderMode : byte {
        None,
        Auto, // It will select Gpu if CUDA verison, or Cpu otherwise
        Cpu,
        Gpu,
    }
    // From OpenPose: op::ElementToRender
    public enum ElementToRender : byte {
        Skeleton,
        Background,
        AddKeypoints,
        AddPAFs,
    }
	// From OpenPose: op::PoseModel
    public enum PoseModel : byte {
        /**
         * COCO + 6 foot keypoints + neck + lower abs model, with 25+1 components (see poseParameters.hpp for details).
         */
        BODY_25 = 0,
        COCO_18,        /**< COCO model + neck, with 18+1 components (see poseParameters.hpp for details). */
        MPI_15,         /**< MPI model, with 15+1 components (see poseParameters.hpp for details). */
        MPI_15_4,       /**< Variation of the MPI model, reduced number of CNN stages to 4: faster but less accurate.*/
        BODY_19,        /**< Experimental. Do not use. */
        BODY_19_X2,     /**< Experimental. Do not use. */
        BODY_59,        /**< Experimental. Do not use. */
        BODY_19N,       /**< Experimental. Do not use. */
        BODY_25E,       /**< Experimental. Do not use. */
        BODY_25_19,     /**< Experimental. Do not use. */
        BODY_65,        /**< Experimental. Do not use. */
        CAR_12,         /**< Experimental. Do not use. */
        BODY_25D,       /**< Experimental. Do not use. */
        BODY_23,        /**< Experimental. Do not use. */
        CAR_22,         /**< Experimental. Do not use. */
        Size,
    }	
    // From OpenPose: op::DisplayMode
    public enum DisplayMode : ushort {
        NoDisplay,  /**< No display. */
        DisplayAll, /**< All (2-D and 3-D/Adam) displays */
        Display2D,  /**< Only 2-D display. */
        Display3D,  /**< Only 3-D display. */
        DisplayAdam /**< Only Adam display. */
    }
	// From OpenPose: op::DataFormat
    public enum DataFormat : byte {
        Json,
        Xml,
        Yaml,
        Yml,
    };
}
