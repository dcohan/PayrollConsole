@echo off
set currPath=%~dp0
set currDrive=%~dd0

subst n: /D
subst n: "%currPath%"
n:

echo Building the app
SET MSBUILD_PATH=%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe
echo Building the app Backoffice.WebApp
call Tools\Nuget\nuget.exe restore "PayrollConsole.sln"
call "%MSBUILD_PATH%" "PayrollConsole.sln" /nologo /verbosity:m /t:Clean,Build /p:AutoParameterizationWebConfigConnectionStrings=false;Configuration=Debug;UseSharedCompilation=false /p:SolutionDir="." 

"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\MSTest.exe" /testcontainer:".\PayrollConsole.Tests\bin\Debug\PayrollConsole.Tests.dll"

:end
pause
