:: Avoid printing all the comments in the Windows cmd
@echo off

SET UNZIP_EXE=3rdparty\unzip\unzip.exe
SET WGET_EXE=3rdparty\wget\wget.exe

:: Address & Paths
SET PACKAGE_LINK=https://github.com/CMU-Perceptual-Computing-Lab/openpose/releases/download/v1.5.0/openpose-1.5.0-binaries-win64-gpu-unity.zip
SET PACKAGE_NAME=openpose-1.5.0-binaries-win64-gpu-unity
SET FOLDER_NAME=openpose-1.5.0-binaries-win64-gpu-python-flir-3d_unity

SET ZIP_EXT=.zip
SET EXCLUDE_FILE=xcopy_exclude.txt
SET BINARY_FOLDER=openpose-binary
SET LIB_PATH=%BINARY_FOLDER%\bin
SET PLUGINS_PATH=OpenPosePlugin\Assets\OpenPose\Plugins\

echo ----- Deleting old plugins -----
rd /s/q %PLUGINS_PATH%
echo:

echo ----- Deleting old binary -----
rd /s/q %BINARY_FOLDER%
echo:

echo ----- Downloading Plugins -----
%WGET_EXE% -c %PACKAGE_LINK%
echo:

echo ----- Unzipping Plugins -----
%UNZIP_EXE% %PACKAGE_NAME%%ZIP_EXT%
ren %FOLDER_NAME% %BINARY_FOLDER%
echo:

echo ----- Deleting Temporary Zip File %PACKAGE_NAME%%ZIP_EXT% -----
del /q "%PACKAGE_NAME%%ZIP_EXT%"
echo: 

echo ----- Copying Plugins -----
xcopy /s /q /i /exclude:%EXCLUDE_FILE% %LIB_PATH% %PLUGINS_PATH%
echo:



