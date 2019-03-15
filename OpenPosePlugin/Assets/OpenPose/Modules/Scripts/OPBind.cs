// OpenPose Unity Plugin v1.0.0alpha-1.5.0
using System;
using System.Runtime.InteropServices;

namespace OpenPose {
    /*
     * Bind to OpenPose C++ library (openpose.dll)
     * Do not use the functions in this class unless you really understand them
     * Use OPWrapper instead
     */
    public static class OPBind {

        // Output callback delegate
        public delegate void OutputCallback(IntPtr ptrs, int ptrSize, IntPtr sizes, int sizeSize, byte outputType);

        // Logging callback delegate
        public delegate void DebugCallback(string message, int type);

        /*
         * Send a callback function to openpose output. No output will be received if no callback is sent.
         * Enable/disable the output callback. Can be set at runtime.
         */
        [DllImport("openpose")] public static extern void _OPRegisterOutputCallback(OutputCallback callback);
        [DllImport("openpose")] public static extern void _OPSetOutputEnable(bool enable);

        /*
         * Send a callback function to openpose logging system. No message will be received if no callback is sent.`
         * The function will be called in op::log() or op::logError().
         * Enable/disable the debug callback. Can be set at runtime.
         */
        [DllImport("openpose")] public static extern void _OPRegisterDebugCallback(DebugCallback callback);
        [DllImport("openpose")] public static extern void _OPSetDebugEnable(bool enable);

        /*
         * Enable/disable image output callback. Disable will save some time since data is large.
         */
        [DllImport("openpose")] public static extern void _OPSetImageOutputEnable(bool enable);

        /*
         * Run openpose if not running. It may take several seconds to fully start.
         */
        [DllImport("openpose")] public static extern void _OPRun();

        /*
         * Shut down openpose program if it is running. It may take several seconds to fully stop it.
         */
        [DllImport("openpose")] public static extern void _OPShutdown();

        /*
         * Openpose configurations - please read openpose documentation for explanation
         */
        [DllImport("openpose")] public static extern void _OPConfigurePose(
            byte poseMode, int netInputSizeX, int netInputSizeY, // Point
            int outputSizeX, int outputSizeY, // Point
            byte keypointScaleMode, // ScaleMode
            int gpuNumber, int gpuNumberStart, int scalesNumber, float scaleGap,
            byte renderMode, // RenderMode
            byte poseModel, // PoseModel
            bool blendOriginalFrame, float alphaKeypoint, float alphaHeatMap, int defaultPartToRender,
            string modelFolder, bool heatMapAddParts, bool heatMapAddBkg,
            bool heatMapAddPAFs, // vector<HeatMapType>
            byte heatMapScaleMode, // ScaleMode
            bool addPartCandidates, float renderThreshold, int numberPeopleMax,
            bool maximizePositives, double fpsMax, string protoTxtPath, string caffeModelPath, float upsamplingRatio
        );
        [DllImport("openpose")] public static extern void _OPConfigureHand(
            bool enable, byte detector, int netInputSizeX, int netInputSizeY, // Point
            int scalesNumber, float scaleRange, byte renderMode, // RenderMode
            float alphaKeypoint, float alphaHeatMap, float renderThreshold
        );
        [DllImport("openpose")] public static extern void _OPConfigureFace(
            bool enable, byte detector, int netInputSizeX, int netInputSizeY, // Point
            byte renderMode, // RenderMode
            float alphaKeypoint, float alphaHeatMap, float renderThreshold
        );
        [DllImport("openpose")] public static extern void _OPConfigureExtra(
            bool reconstruct3d, int minViews3d, bool identification, int tracking, int ikThreads
        );
        [DllImport("openpose")] public static extern void _OPConfigureInput(
            byte producerType, string producerString, // ProducerType and string
            ulong frameFirst, ulong frameStep, ulong frameLast,
            bool realTimeProcessing, bool frameFlip, int frameRotate, bool framesRepeat,
            int cameraResolutionX, int cameraResolutionY, // Point
            string cameraParameterPath, bool undistortImage, int numberViews
        );
        [DllImport("openpose")] public static extern void _OPConfigureOutput(
            double verbose, string writeKeypoint, byte writeKeypointFormat, // DataFormat
            string writeJson, string writeCocoJson, int writeCocoJsonVariants, int writeCocoJsonVariant,
            string writeImages, string writeImagesFormat, string writeVideo, double writeVideoFps, bool writeVideoWithAudio,
            string writeHeatMaps, string writeHeatMapsFormat, string writeVideo3D, string writeVideoAdam,
            string writeBvh, string udpHost, string udpPort
        );
        [DllImport("openpose")] public static extern void _OPConfigureGui(
            ushort displayMode, // DisplayMode
            bool guiVerbose, bool fullScreen
        );
        [DllImport("openpose")] public static extern void _OPConfigureDebugging(
            byte loggingLevel, // Priority
			bool disableMultiThread, ulong profileSpeed
        );
    }
}
