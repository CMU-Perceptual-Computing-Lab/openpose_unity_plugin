﻿// OpenPose Unity Plugin v1.0.0alpha-1.5.0
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

namespace OpenPose {
    /*
     * OPWrapper wraps OpenPose API and provide a friendly user function set
     */
    public class OPWrapper : MonoBehaviour {

        # region Properties
        // State
        public static OPState state { get; private set; }

        // Output
        private static OPDatum currentData;
        private static bool dataFlag = false;

        // Thread
        private static Thread opThread;
        # endregion

        # region User functions
        // Register debug and output callback (only need to call once)
        public static void OPRegisterCallbacks(){
            OPBind._OPRegisterDebugCallback(OPLog);
            OPBind._OPRegisterOutputCallback(OPOutput);
        }
        // Enable debug message from OpenPose (default true). Can set in run-time
        public static void OPEnableDebug(bool enable){
            OPBind._OPSetDebugEnable(enable);
        }
        // Enable receiving output from OpenPose (default true). Can set in run-time
        public static void OPEnableOutput(bool enable){
            OPBind._OPSetOutputEnable(enable);
        }
        // Enable multi-thread (default true). Only set during configure
        public static void OPEnableMultiThread(bool enable){
            OPBind._OPSetMultiThreadEnable(enable);
        }
        // Enable receiving camera image from OpenPose (default false). Can set in run-time
        public static void OPEnableImageOutput(bool enable){
            OPBind._OPSetImageOutputEnable(enable);
        }
        // Lazy way to configure all parameters in default
        public static void OPConfigureAllInDefault(){
            OPConfigurePose();
            OPConfigureHand();
            OPConfigureFace();
            OPConfigureExtra();
            OPConfigureInput();
            OPConfigureOutput();
            OPConfigureGui();
        }
        // Start OpenPose thread with last configuration parameters
        public static void OPRun() {
            if (state == OPState.Ready) {
                // Start OP thread
                state = OPState.Running;
                opThread = new Thread(new ThreadStart(OPExecuteThread));
                opThread.Start();
            } else {
                Debug.LogWarning("Trying to start, while OpenPose already started or not ready");
            }
        }
        // Get output if output arrives IN THIS FRAME.
        // Suggested to call this function in Update()
        public static bool OPGetOutput(out OPDatum data){
            data = currentData;
            return dataFlag;
        }
        // Stop OpenPose if running
        public static void OPShutdown() {
            if (state == OPState.Running) {
                state = OPState.Stopping;
                OPBind._OPShutdown();
            } else {
                Debug.LogWarning("Trying to shutdown, while OpenPose is not running");
            }
        }
        // Pose parameter configuration (with default value)
        // Please see OpenPose documentation for explanation on every parameter
        public static void OPConfigurePose(
            bool enable = true, Vector2Int? netInputSize = null, Vector2Int? outputSize = null,
            ScaleMode keypointScaleMode = ScaleMode.InputResolution,
            int gpuNumber = -1, int gpuNumberStart = 0, int scalesNumber = 1, float scaleGap = 0.3f,
            RenderMode renderMode = RenderMode.Gpu, PoseModel poseModel = PoseModel.BODY_25,
            bool blendOriginalFrame = true, float alphaKeypoint = 0.6f, float alphaHeatMap = 0.7f,
            int defaultPartToRender = 0, string modelFolder = null,
            HeatMapType heatMapTypes = HeatMapType.None, ScaleMode heatMapScaleMode = ScaleMode.UnsignedChar,
            bool addPartCandidates = false, float renderThreshold = 0.05f, int numberPeopleMax = -1,
            bool maximizePositives = false, double fpsMax = -1.0,
            string protoTxtPath = "", string caffeModelPath = ""){

            // Other default values
            Vector2Int _netRes = netInputSize ?? new Vector2Int(-1, 368);
            Vector2Int _outputRes = outputSize ?? new Vector2Int(-1, -1);
            modelFolder = modelFolder ?? Application.streamingAssetsPath + "/models/";

            OPBind._OPConfigurePose(
                enable, _netRes.x, _netRes.y, // Point
                _outputRes.x, _outputRes.y, // Point
                (byte) keypointScaleMode, // ScaleMode
                gpuNumber, gpuNumberStart, scalesNumber, scaleGap,
                (byte) renderMode, // RenderMode
                (byte) poseModel, // PoseModel
                blendOriginalFrame, alphaKeypoint, alphaHeatMap, defaultPartToRender, modelFolder,
                Convert.ToBoolean(heatMapTypes & HeatMapType.Parts),
                Convert.ToBoolean(heatMapTypes & HeatMapType.Background),
                Convert.ToBoolean(heatMapTypes & HeatMapType.PAFs), // vector<HeatMapType>
                (byte) heatMapScaleMode, // ScaleMode
                addPartCandidates, renderThreshold, numberPeopleMax,
                maximizePositives, fpsMax, protoTxtPath, caffeModelPath
            );
        }
        // Hand parameter configuration (with default value)
        // Please see OpenPose documentation for explanation on every parameter
        public static void OPConfigureHand(
            bool enable = false, Detector detector = Detector.Body, Vector2Int? netInputSize = null,
            int scalesNumber = 1, float scaleRange = 0.4f, RenderMode renderMode = RenderMode.None,
            float alphaKeypoint = 0.6f, float alphaHeatMap = 0.7f, float renderThreshold = 0.2f){

            // Other default values
            Vector2Int _netInputSize = netInputSize ?? new Vector2Int(368, 368);

            OPBind._OPConfigureHand(
                enable, (byte) detector, _netInputSize.x, _netInputSize.y, // Point
                scalesNumber, scaleRange, (byte) renderMode, // RenderMode
                alphaKeypoint, alphaHeatMap, renderThreshold
            );
        }
        // Face parameter configuration (with default value)
        // Please see OpenPose documentation for explanation on every parameter
        public static void OPConfigureFace(
            bool enable = false, Detector detector = Detector.Body,
            Vector2Int? netInputSize = null, RenderMode renderMode = RenderMode.None,
            float alphaKeypoint = 0.6f, float alphaHeatMap = 0.7f, float renderThreshold = 0.4f){

            // Other default values
            Vector2Int _netInputSize = netInputSize ?? new Vector2Int(368, 368);

            OPBind._OPConfigureFace(
                enable, (byte) detector, _netInputSize.x, _netInputSize.y, // Point
                (byte) renderMode, // RenderMode
                alphaKeypoint, alphaHeatMap, renderThreshold
            );
        }
        // Extra parameter configuration (with default value)
        // NOTICE: 3D output is not yet supported currently
        // Please see OpenPose documentation for explanation on every parameter
        public static void OPConfigureExtra(
            bool reconstruct3d = false, int minViews3d = -1, bool identification = false, int tracking = -1,
            int ikThreads = 0){

            OPBind._OPConfigureExtra(reconstruct3d, minViews3d, identification, tracking, ikThreads);
        }
        // Input parameter configuration (with default value)
        // Please see OpenPose documentation for explanation on every parameter
        public static void OPConfigureInput(
            ProducerType producerType = ProducerType.Webcam, string producerString = "-1",
            ulong frameFirst = 0, ulong frameStep = 1, ulong frameLast = ulong.MaxValue,
            bool realTimeProcessing = false, bool frameFlip = false,
            int frameRotate = 0, bool framesRepeat = false,
            Vector2Int? cameraResolution = null, string cameraParameterPath = null,
            bool undistortImage = false, int numberViews = -1){

            // Other default values
            Vector2Int _cameraResolution = cameraResolution ?? new Vector2Int(-1, -1);
            cameraParameterPath = cameraParameterPath ?? Application.streamingAssetsPath + "/models/cameraParameters/";

            OPBind._OPConfigureInput(
                (byte) producerType, producerString, // ProducerType and string
                frameFirst, frameStep, frameLast,
                realTimeProcessing, frameFlip, frameRotate, framesRepeat,
                _cameraResolution.x, _cameraResolution.y, // Point
                cameraParameterPath, undistortImage, numberViews
            );
        }
        // Output parameter configuration (with default value)
        // Please see OpenPose documentation for explanation on every parameter
        public static void OPConfigureOutput(
            double verbose = -1.0, string writeKeypoint = "", DataFormat writeKeypointFormat = DataFormat.Yml,
            string writeJson = "", string writeCocoJson = "", string writeCocoFootJson = "",
            int writeCocoJsonVariant = 1, string writeImages = "", string writeImagesFormat = "png",
            string writeVideo = "", double writeVideoFps = 30.0, bool writeVideoWithAudio = false, string writeHeatMaps = "",
            string writeHeatMapsFormat = "png", string writeVideo3D = "", string writeVideoAdam = "",
            string writeBvh = "", string udpHost = "", string udpPort = "8051"){

            OPBind._OPConfigureOutput(
                verbose, writeKeypoint, (byte) writeKeypointFormat, // DataFormat
                writeJson, writeCocoJson, writeCocoFootJson, 
                writeCocoJsonVariant, writeImages, writeImagesFormat, 
                writeVideo, writeVideoFps, writeVideoWithAudio, writeHeatMaps, 
                writeHeatMapsFormat, writeVideo3D, writeVideoAdam, 
                writeBvh, udpHost, udpPort
            );
        }
        // GUI parameter configuration (with default value)
        // Please see OpenPose documentation for explanation on every parameter
        public static void OPConfigureGui(
            DisplayMode displayMode = DisplayMode.NoDisplay,
            bool guiVerbose = false, bool fullScreen = false){

            OPBind._OPConfigureGui(
                (ushort) displayMode, // DisplayMode
                guiVerbose, fullScreen
            );
        }
        # endregion

        # region Unity callbacks
        // Log callback
        private static OPBind.DebugCallback OPLog = delegate(string message, int type){
            switch (type){
                case 0: Debug.Log("OP_Log: " + message); break;
                case 1: Debug.LogWarning("OP_Warning: " + message); break;
                case -1: Debug.LogError("OP_Error: " + message);
                    //opThread.Abort();
                    break;
            }
        };

        // Output callback
        private static OPBind.OutputCallback OPOutput = delegate(IntPtr ptrPtr, int ptrSize, IntPtr sizePtr, int sizeSize, byte outputType){
            // End of frame signal is received, turn on the flag
            if ((OutputType)outputType == OutputType.None) {
                dataFlag = true;
                return;
            }

            // Safety check
            if (ptrSize < 0 || sizeSize < 0) return;

            // Parse ptrPtr to ptrArray
            var ptrArray = new IntPtr[ptrSize];
            Marshal.Copy(ptrPtr, ptrArray, 0, ptrSize);

            // Parse sizePtr to sizeArray
            var sizeArray = new int[sizeSize];
            Marshal.Copy(sizePtr, sizeArray, 0, sizeSize);

            // Write output to data struct
            OPOutputParser.ParseOutput(ref currentData, ptrArray, sizeArray, (OutputType)outputType);
        };
        # endregion

        # region OpenPose thread
        // OP thread
        private static void OPExecuteThread() {
            // Start OP with output callback
            OPBind._OPRun();

            // Thread end, change state
            state = OPState.Ready;
        }
        # endregion

        # region MonoBehaviour
        private IEnumerator Start() {
            // Change state
            state = OPState.Ready;
            // Check if data receive finished every frame
            while (true) {
                // New data finished
                yield return new WaitForEndOfFrame();
                if (dataFlag) {
                    dataFlag = false;
                    currentData = new OPDatum();
                }
            }
        }

        private void OnDestroy() {
            // Stop openpose
            if (state == OPState.Running) OPShutdown();
        }
        # endregion
    }
}
