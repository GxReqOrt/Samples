@echo off

rem run on visual studio developer console as admin

set GX_PROGRAM_DIR=C:\Program Files (x86)\GeneXus\GeneXus17
set GX_SDK_DIR=C:\Program Files (x86)\GeneXus\GeneXus17PlatformSDK

for /f "delims=" %%a in ('dir /b/s *.sln') do set SLN_PATH=%%a 

devenv %SLN_PATH%
