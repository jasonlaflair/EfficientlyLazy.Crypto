
$buildLevelDebug = "Debug"
$buildLevelQA = "QA"
$buildLevelRelease = "Release"

$buildLevel = NIL

$msbuild = "\"C:/WINDOWS/Microsoft.NET/Framework/v3.5/MSBuild.exe\""
$solutionFiles = FileList[$solutionRoot + "/*.sln"]

$nCover = "\"c:/Program Files/NCover/NCoverExplorer.Console.exe\""
$nCoverConfig = "\"#{$rootBuildPath}/teamCity.ncover\""

$GallioUnitTestRunner = "\"#{$solutionRoot}/ThirdParty/Gallio/Gallio.Echo.exe\""

$shfb = 'C:\\Program Files (x86)\\EWSoftware\\Sandcastle Help File Builder\\SandcastleBuilderConsole.exe'

$packageLib20 = 'Package\\lib\\v20\\'
$packageLib35 = 'Package\\lib\\v35\\'
$packageDemo = 'Package\\Demo\\'

