@solutionRoot = File.dirname(Rake.original_dir)

@buildLevel = NIL

@msbuild = 'C:\\WINDOWS\\Microsoft.NET\\Framework\\v3.5\\MSBuild.exe'
@solutionFiles = FileList[@solutionRoot + "/*.sln"]

@nCover = 'c:\\Program Files\\NCover\\NCoverExplorer.Console.exe'
@nCoverConfig = '"' + Rake.original_dir + '/config.ncover"'

@GallioUnitTestRunner = @solutionRoot + '\\ThirdParty\\Gallio\\Gallio.Echo.exe'
#@unitTestAssmMask = FileList["Tests/**/bin/Debug/*.Test.dll"]

@shfb = 'C:\\Program Files (x86)\\EWSoftware\\Sandcastle Help File Builder\\SandcastleBuilderConsole.exe'

@packageLib20 = 'Package\\lib\\v20\\'
@packageLib35 = 'Package\\lib\\v35\\'
@packageDemo = 'Package\\Demo\\'

