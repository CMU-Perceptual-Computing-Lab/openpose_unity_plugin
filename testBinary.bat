:: Avoid printing all the comments in the Windows cmd
@echo on

SET BINARY_ROOT=openpose-binary\
SET MODELS_FOLDER=models
SET GET_MODELS=.\getModels.bat
SET DEMO=.\bin\OPenPoseDemo.exe
SET ARGS=--video .\examples\media\video.avi
SET ARGS_LOWRES=%ARGS% --net_resolution -1x80
SET ARGS_CPU=ARGS% --render_pose 1

echo ----- Entering binary root folder %BINARY_ROOT% -----
IF EXIST %BINARY_ROOT% (
	echo Done 
) ELSE (
	echo No Binary folder exist, please run get_plugins.bat
	pause
	exit
)
cd %BINARY_ROOT%
echo:

echo ----- Getting models for openpose binary -----
cd %MODELS_FOLDER%
call %GET_MODELS%
cd ..
echo:

echo ----- Running OpenPose Demo in video mode -----
:: With default settings
%DEMO% %ARGS%
:: With low resolution
::%DEMO% %ARGS_LOWRES%
:: With CPU mode
::%DEMO% %ARGS_CPU%
echo:
