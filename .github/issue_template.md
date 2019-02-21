### Posting rules
1. **Duplicated posts will not be answered**. Check the [FAQ](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/faq.md) section, other GitHub issues, and general documentation before posting. E.g., **low-speed, out-of-memory, output format, 0-people detected, installation issues, ...**).
2. **Fill** the **Your System Configuration section (all of it or it will not be answered!)** if you are facing an error or unexpected behavior. Feature requests or some other type of posts might not require it.
3. **No questions about OpenPose or 3rd party libraries**:
    - OpenPose-related issues should check the [official OpenPose GitHub repository](https://github.com/CMU-Perceptual-Computing-Lab/openpose).
    - Caffe errors/issues, check [Caffe](http://caffe.berkeleyvision.org) documentation.
    - CUDA check failed errors: They are usually fixed by re-installing CUDA, then re-installing the proper cuDNN version, and then re-compiling (or re-installing) OpenPose. Otherwise, check for help in CUDA forums.
    - OpenCV errors: Install the default/pre-compiled OpenCV or check for online help.
4. Set a **proper issue title**: add the Ubuntu/Windows keyword and be specific (e.g., do not call it: `Error`).
5. Only English comments.
Posts which do not follow these rules will be **ignored, closed, or reported** with no further clarification.



### Issue Summary



### Executed Command (if any)



### OpenPose Output (if any)



### Errors (if any)



### Type of Issue
You might select multiple topics, delete the rest:
- Compilation/installation error
- Execution error
- Help wanted
- Question
- Enhancement / offering possible extensions / pull request / etc
- Other (type your own type)



### Your System Configuration
1. **Whole console output** (if errors appeared), paste the error to [PasteBin](https://pastebin.com/) and then paste the link here: LINK

2. **OpenPose version**: OpenPose Unity Plugin default? Or specific commit (e.g., d52878f)? Or specific version from `Release` section (e.g., 1.5.0)?

3. **General configuration**:
    - **Operating system** (`lsb_release -a` in Ubuntu):
    - **Release or Debug mode**? (by default: release):
    - Compiler (`gcc --version` in Ubuntu or VS version in Windows): 5.4.0, ... (Ubuntu); VS2015 Enterprise Update 3, VS2017 community, ... (Windows); ...?

4. **Non-default settings**:
    - Any custom OpenPose configuration with respect to the default version? (by default: no):

5. **3rd-party software**:
    - **Caffe version**: Default from OpenPose, custom version, ...?
    - **OpenCV version**: pre-compiled `apt-get install libopencv-dev` (only Ubuntu); OpenPose default (only Windows); compiled from source? If so, 2.4.9, 2.4.12, 3.1, 3.2?; ...?

6. If **GPU mode** issue:
    - **CUDA version** (`cat /usr/local/cuda/version.txt` in most cases):
    - **cuDNN version**:
    - **GPU model** (`nvidia-smi` in Ubuntu):

7. If **CPU-only mode** issue:
    - **CPU brand & model**:
    - Total **RAM memory** available:

8. If **Windows** system:
    - Default OpenPose DLL or Portable demo or compiled library?

9. If **speed performance** issue:
    - Run the OpenPose binaries and report the OpenPose timing speed based on [this link](https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/installation.md#profiling-speed).
