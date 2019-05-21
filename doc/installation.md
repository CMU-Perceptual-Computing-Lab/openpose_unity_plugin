# OpenPose Plugin for Unity - Documentation



## Operating Systems
- **Windows** 7, 8, 10.



## Software Versions
- Unity versions: 2018.3, 2018.4. Previous versions may work as well but issues won't be answered.
- Unity 2019.1 is not fully supported yet. There are a few cases that Unity 2019 will crash with the lastest plugin version. You may try it but it is not guaranteed to work. If Unity 2019 crashes, use Unity 2018.4 instead. 
- [**OpenPose**](https://github.com/CMU-Perceptual-Computing-Lab/openpose) version 1.5 or newer (version 1.5 comes by default).



## Running the OpenPose Unity Demo
- Clone or download the project into your local machine, and open your root folder. 
- Run `getPlugins.bat`. This will automatically download and unzip OpenPose binaries and copy dlls to Unity. (After this step, it's OK to delete `openpose-binary` folder if you don't need it anymore.)
- Run `getModels.bat`. This will automatically download required models for OpenPose.
- Open scene `Demo.unity` (located in `OpenPosePlugin/Assets/OpenPose/Examples/Scenes/`) in Unity and click "run".
- (Optional) Read the [UML diagram](./OpenPoseUnityPlugin_UML.pdf) for more information.



## Having issues
If you are having fatal issues (e.g. Unity crashes) in running Unity Demo, please follow these steps to check: 
 - Re-run `getPlugins.bat` and `getModels.bat` and try again. 
 - Go to the root folder and run `testBinary.bat`. This will run OpenPose binary demo in video mode. If successful, OpenPose window should appear and a video should play slowly, with markers on the human bodies. 
 - If the binary runs well but Unity still crashes, please report the issue in GitHub with your specific information. 
 - If the binary fails, there might be the following reasons: 
   1. Your GPU has not enough memory: You may try reducing resolution or running in CPU mode in OpenPose binary. Please edit `testBinary.bat` and follow the comments inside. Then do the same settings in Unity. 
   2. Placeholder for other possible reasons 
 - If things still break, please report the issue in GitHub and we will look into that. 
 


## Updating OpenPose Unity Plugin
If you have successfully run the demo before, you can follow this updating procedure instead of re-installing it: 
 - Re-run `getPlugins.bat` in the **root** folder. This will automatically update new plugins. 
 - Run the demo. It should work. 



## Advanced options
- If you plan to compile and install the OpenPose C++ library on the same machine (e.g., if you plan to use the latest GitHub version rather than the latest official release or if you intend to modify the OpenPose C++ library):
    1. [Install the OpenPose prerequisites](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/installation.md#prerequisites).
    2. [Install OpenPose](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/installation.md) and make sure the `BUILD_UNITY_SUPPORT` flag is enabled in CMake-GUI.
    3. Make sure that OpenPose works properly by [running the default examples](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/quick_start.md#quick-start).
    4. **Note: OpenPose has been tested extensively with CUDA 10.0 / cuDNN 7.5 for VS2017 and CUDA 8.0 / cuDNN 5.1 for VS 2015.** We highly recommend using those versions to minimize potential installation issues. Other versions should also work, but we do not provide support about any CUDA/cuDNN installation/compilation issue, as well as problems related to their integration into OpenPose.
    5. If you desire to use OpenPose with VS 2015 and you already installed VS 2017, you have to:
        1. Uninstall VS 2015 and 2017.
        2. Install the OpenPose prerequisites (VS 2015, CUDA 8, cuDNN 5.1). Not re-installing VS 2015 after uninstalling VS 2017 might lead to really cryptic bugs in VS 2015 when compiling OpenPose.
        3. Install OpenPose following the above steps.
    6. Unity versions tested and officially supported only for higher or equal than 2018.2.9f1. Lower versions might also work. 


## Extra information
See [./OpenPosePlugin/Assets/OpenPose/Documents/OpenPoseUnityPlugin_UML.pdf](./OpenPoseUnityPlugin_UML.pdf) or [./OpenPosePlugin/Assets/OpenPose/Documents/OpenPoseUnityPlugin_UML.mdj](./OpenPoseUnityPlugin_UML.mdj) (StarUML editable file) for a very basic UML description of this Unity project.



## Reporting Bugs, Issues, and Feedback
We welcome any feedback on our library. For that, [create a new GitHub issue](https://github.com/CMU-Perceptual-Computing-Lab/openpose_unity_plugin/issues/new) in our GitHub repository. If it is a bug, please, fill all the `Your System Configuration` information so we can better debug it.
