@ECHO OFF

REM Comment this out to use the installed version of the tools
REM SET DXROOT=C:\CP\TFS05\Sandcastle\Main\

ECHO *
ECHO * Building .NET Framework reflection data files using tools in %DXROOT%
ECHO *

CD %DXROOT%\Data

IF EXIST ".\Reflection\*.xml" DEL /Q .\Reflection\*.*

REM Determine the most recent .NET version installed
SET DNVER=4.0

REM IF EXIST "%WINDIR%\Microsoft.NET\Framework\v4.0.30319\*.*" SET DNVER=4.0

"%WINDIR%\Microsoft.Net\Framework\v4.0.30319\msbuild.exe" "BuildReflectionData.proj" /p:NetfxVer=%DNVER%
IF ERRORLEVEL 1 GOTO BuildFailed

RD /S /Q ".\Tmp"
DEL MRefBuilder.rsp

ECHO *
ECHO * The reflection data has been built successfully
ECHO *

GOTO Done

:BuildFailed

ECHO *
ECHO * Build failed!
ECHO *

:Done
