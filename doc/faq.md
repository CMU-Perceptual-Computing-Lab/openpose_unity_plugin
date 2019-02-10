OpenPose Unity Plugin - Frequently Asked Question (FAQ)
============================================

## Contents
1. [FAQ](#faq)
    1. [Unity Crashes](#unity-crashes)
    2. [Unity Crashes after Updating OpenPose Unity Plugin](#Unity-crashes-after-updating-openpose-unity-wrapper)

## FAQ
### Unity Crashes
**Q: Unity crashes** - Unity crashes when I run the program.

**A**: Unity crashes when OpenPose crashes. Try the following methods to detect the error:

1. Try making sure models and plugins are correctly downloaded. Read [installation.md](./installation.md) for details.
2. Try reducing net_resolution to smaller number (e.g. 80) and disabling face/hands.
3. Try running OpenPose C++ binaries. More information will be provided.



### Unity Crashes after Updating OpenPose Unity Plugin
**Q: Unity crashes** - Unity crashes when I run the program after I have updated the code from GitHub. The previous version was working just fine.

**A**: If you update the OpenPose Unity Plugin version and it start crashing, most probably the OpenPose DLL code has been modified. If so, you should remove `OpenPosePlugin/Assets/OpenPose/Plugins` and `OpenPosePlugin/Assets/OpenPose/Plugins_YYYY_MM_DD.zip` and re-run `getPlugins.bat` (located in `OpenPosePlugin/Assets/OpenPose/`).
