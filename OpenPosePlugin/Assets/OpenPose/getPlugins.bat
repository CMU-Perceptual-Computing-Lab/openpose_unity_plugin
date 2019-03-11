:: Avoid printing all the comments in the Windows cmd
@echo off

SET UNZIP_EXE=..\..\..\3rdparty\unzip\unzip.exe
SET WGET_EXE=..\..\..\3rdparty\wget\wget.exe

:: Download temporary zip
echo ----- Downloading Plugins -----
SET OPENPOSE_UNITY_URL=http://posefs1.perception.cs.cmu.edu/OpenPose/unity/
SET PLUGINS_FOLDER=Plugins\
SET ZIP_NAME=Plugins_2019_02_21.zip
SET ZIP_FULL_PATH=%PLUGINS_FOLDER%%ZIP_NAME%
%WGET_EXE% -c %OPENPOSE_UNITY_URL%%ZIP_NAME% -P %PLUGINS_FOLDER%
echo:

echo ----- Unzipping Plugins -----
%UNZIP_EXE% %ZIP_FULL_PATH%
echo:

echo ----- Deleting Temporary Zip File %ZIP_FULL_PATH% -----
del "%ZIP_FULL_PATH%"

echo ----- Plugins Downloaded and Unzipped -----
