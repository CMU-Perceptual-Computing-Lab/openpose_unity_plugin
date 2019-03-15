# OpenPose Plugin for Unity - Documentation



## Operating Systems
- **Windows** 7, 8, 10.



## Software Versions
- Unity versions higher or equal than 2018.2.9f1. Previous versions may work as well.
- [**OpenPose**](https://github.com/CMU-Perceptual-Computing-Lab/openpose) version 1.5 or newer (version 1.5 comes by default).



## Updating OpenPose Unity Plugin
If you update the OpenPose Unity Plugin version and it start crashing, most probably the OpenPose DLL code has been modified. If so, you should remove `OpenPosePlugin/Assets/OpenPose/Plugins` and `OpenPosePlugin/Assets/OpenPose/Plugins_YYYY_MM_DD.zip` and re-run `getPlugins.bat` (located in `OpenPosePlugin/Assets/OpenPose/`).



## Prerequisites
- If you plan to use the default OpenPose DLL (recommended):
    - Make sure that the [latest OpenPose portable demo](https://github.com/CMU-Perceptual-Computing-Lab/openpose/releases) works properly by running the default examples following the [OpenPose doc/quick_start.md#quick-start](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/quick_start.md#quick-start).
- If you also plan to compile and install the OpenPose C++ library on the same machine (e.g., if you plan to use the latest GitHub version rather than the latest official release or if you intend to modify the OpenPose C++ library):
    1. [Install the OpenPose prerequisites](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/installation.md#prerequisites).
    2. [Install OpenPose](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/installation.md) and make sure the `BUILD_UNITY_SUPPORT` flag is enabled in CMake-GUI.
    3. Make sure that OpenPose works properly by [running the default examples](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/quick_start.md#quick-start).
    4. **Note: OpenPose has been tested extensively with CUDA 10.0 / cuDNN 7.5 for VS2017 and CUDA 8.0 / cuDNN 5.1 for VS 2015.** We highly recommend using those versions to minimize potential installation issues. Other versions should also work, but we do not provide support about any CUDA/cuDNN installation/compilation issue, as well as problems related to their integration into OpenPose.
    5. If you desire to use OpenPose with VS 2015 and you already installed VS 2017, you have to:
        1. Uninstall VS 2015 and 2017.
        2. Install the OpenPose prerequisites (VS 2015, CUDA 8, cuDNN 5.1). Not re-installing VS 2015 after uninstalling VS 2017 might lead to really cryptic bugs in VS 2015 when compiling OpenPose.
        3. Install OpenPose following the above steps.
    6. Unity versions tested and officially supported only for higher or equal than 2018.2.9f1. Lower versions might also work. 



## Running the OpenPose Unity Demo
- Clone or download the project into your local machine.
- Go to `OpenPosePlugin/Assets/OpenPose/` folder and run `getPlugins.bat`. This will automatically download and unzip OpenPose plugins.
- Go to `OpenPosePlugin/Assets/StreamingAssets/models/` folder and run `getModels.bat`. This will automatically download required models for OpenPose.
- Open Unity editor and run the `Demo.unity` in `OpenPosePlugin/Assets/OpenPose/Examples/Scenes/`.
- (Optional) Read the [UML diagram](./OpenPoseUnityPlugin_UML.pdf) for more information.



## Extra information
See [./OpenPosePlugin/Assets/OpenPose/Documents/OpenPoseUnityPlugin_UML.pdf](./OpenPoseUnityPlugin_UML.pdf) or [./OpenPosePlugin/Assets/OpenPose/Documents/OpenPoseUnityPlugin_UML.mdj](./OpenPoseUnityPlugin_UML.mdj) (StarUML editable file) for a very basic UML description of this Unity project.



## Reporting Bugs, Issues, and Feedback
We welcome any feedback on our library. For that, [create a new GitHub issue](https://github.com/CMU-Perceptual-Computing-Lab/openpose_unity_plugin/issues/new) in our GitHub repository. If it is a bug, please, fill all the `Your System Configuration` information so we can better debug it.
