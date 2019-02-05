<div align="center">
    <img src=".github/Logo_main_black.png", width="300">
</div>

-----------------

# OpenPose Unity Plugin
[OpenPose](https://github.com/CMU-Perceptual-Computing-Lab/openpose) represents the **first real-time multi-person system to jointly detect human body, hand, facial, and foot keypoints (in total 135 keypoints) on single images**.

This repository is developed to create an OpenPose plugin for Unity users. It uses OpenPose version 1.5 or newer and provides formatted OpenPose output and some examples.

Demo Video: [link](https://youtu.be/Jrcak4n6PG4)

<p align="center">
    <img src="doc/media/main.png", width="480">
</p>



## NOTICE
This is an alpha release, everything is subject to change. The plugin will finally be available in Unity Assets store in the future.



## Contents
1. [Results](#results)
2. [Installation, Reinstallation and Uninstallation](#installation-reinstallation-and-uninstallation)
3. [Authors and Contributors](#authors-and-contributors)
4. [Citation](#citation)
5. [License](#license)



## Results
### Body and Foot Estimation
<p align="center">
    <img src="doc/media/body_foot.png", width="360">
</p>

### Body, Foot, Face, and Hands Estimation
<p align="center">
    <img src="doc/media/hand_face.png", width="360">
</p>



## Installation, Reinstallation and Uninstallation
Follow the steps in [installation documentation](doc/installation.md).


## Authors and Contributors
OpenPose Unity Plugin is authored by [Tianyi Zhao](http://tianyizhao.com), [Gines Hidalgo](https://www.gineshidalgo.com/), and [Yaser Sheikh](http://www.cs.cmu.edu/~yaser/). Currently, it is being maintained by [Tianyi Zhao](http://tianyizhao.com) and [Gines Hidalgo](https://www.gineshidalgo.com/).



## Citation
Please cite these papers in your publications if it helps your research (the face keypoint detector was trained using the procedure described in [Simon et al. 2017] for hands):

    @inproceedings{cao2018openpose,
      author = {Zhe Cao and Gines Hidalgo and Tomas Simon and Shih-En Wei and Yaser Sheikh},
      booktitle = {arXiv preprint arXiv:1812.08008},
      title = {Open{P}ose: realtime multi-person 2{D} pose estimation using {P}art {A}ffinity {F}ields},
      year = {2018}
    }

    @inproceedings{cao2017realtime,
      author = {Zhe Cao and Tomas Simon and Shih-En Wei and Yaser Sheikh},
      booktitle = {CVPR},
      title = {Realtime Multi-Person 2D Pose Estimation using Part Affinity Fields},
      year = {2017}
    }

    @inproceedings{simon2017hand,
      author = {Tomas Simon and Hanbyul Joo and Iain Matthews and Yaser Sheikh},
      booktitle = {CVPR},
      title = {Hand Keypoint Detection in Single Images using Multiview Bootstrapping},
      year = {2017}
    }

    @inproceedings{wei2016cpm,
      author = {Shih-En Wei and Varun Ramakrishna and Takeo Kanade and Yaser Sheikh},
      booktitle = {CVPR},
      title = {Convolutional pose machines},
      year = {2016}
    }

Links to the papers:

- [OpenPose: Realtime Multi-Person 2D Pose Estimation using Part Affinity Fields](https://arxiv.org/abs/1812.08008)
- [Realtime Multi-Person 2D Pose Estimation using Part Affinity Fields](https://arxiv.org/abs/1611.08050)
- [Hand Keypoint Detection in Single Images using Multiview Bootstrapping](https://arxiv.org/abs/1704.07809)
- [Convolutional Pose Machines](https://arxiv.org/abs/1602.00134)



## License
OpenPose Unity Plugin is freely available for free non-commercial use, and may be redistributed under these conditions. Please, see the [license](LICENSE) for further details. Interested in a commercial license? Check this [FlintBox link](https://flintbox.com/public/project/47343/). For commercial queries, use the `Directly Contact Organization` section from the [FlintBox link](https://flintbox.com/public/project/47343/) and also send a copy of that message to [Yaser Sheikh](http://www.cs.cmu.edu/~yaser/).

