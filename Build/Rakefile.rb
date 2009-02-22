$rootBuildPath = File.dirname(__FILE__)
$solutionRoot = File.dirname($rootBuildPath)
$artifacts = "#{$rootBuildPath}/Artifacts"

mkdir ($artifacts) unless File.exist?($artifacts)

$buildLevel = NIL

$msbuild = "\"C:/WINDOWS/Microsoft.NET/Framework/v3.5/MSBuild.exe\""
$solutionFiles = FileList[$solutionRoot + "/*.sln"]

$nCoverExplorer = "\"c:/Program Files/NCover/NCoverExplorer.Console.exe\""
$nCoverConfig = "#{$rootBuildPath}/config.ncover"

$GallioEcho = "\"#{$solutionRoot}/ThirdParty/Gallio/Gallio.Echo.exe\""

$shfb = "C:/Program Files (x86)/EWSoftware/Sandcastle Help File Builder/SandcastleBuilderConsole.exe"

$version = "0.0.0.0"

import "#{$rootBuildPath}/MSBuild.rb"
import "#{$rootBuildPath}/NCover.rb"
import "#{$rootBuildPath}/Gallio.rb"
import "#{$rootBuildPath}/SandCastle.rb"
import "#{$rootBuildPath}/ZipTools.rb"

task :default => :development

task :development => [:setBuildLevelDebug, :compile, :runUnitTests, :runCoverage]
task :release => [:setBuildLevelRelease, :compile, :generateDocs, :packageup]

task :setBuildLevelDebug do
  $buildLevel = "Debug"
  $version = getVersion
end

task :setBuildLevelRelease do
  $buildLevel = "Release"
  $version = getVersion
end

task :compile do
  compile
end

task :runUnitTests do
  runUnitTests
end

task :runCoverage do
  runNCover
end

task :generateDocs do
  buildDocumentation("#{$solutionRoot}/Source/EfficientlyLazyCrypto.v20/EfficientlyLazyCrypto.v20.csproj", "2.0.50727", $version, "EfficientlyLazyCrypto.v20")
  buildDocumentation("#{$solutionRoot}/Source/EfficientlyLazyCrypto.v35/EfficientlyLazyCrypto.v35.csproj", "3.5", $version, "EfficientlyLazyCrypto.v35")
end

task :packageup do
  
  package = "#{$artifacts}/Package"
  mkdir(package) unless File.exist?(package)
  
  require "fileutils"

  folderv20 = "#{$artifacts}/Package/v20"
  mkdir(folderv20) unless File.exist?(folderv20)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazyCrypto.v20/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv20)
  end
  
  cp("#{$artifacts}/EfficientlyLazyCrypto.v20.chm", "#{folderv20}/EfficientlyLazyCrypto.chm")

  folderv35 = "#{$artifacts}/Package/v35"
  mkdir(folderv35) unless File.exist?(folderv35)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazyCrypto.v35/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv35)
  end

  cp("#{$artifacts}/EfficientlyLazyCrypto.v35.chm", "#{folderv35}/EfficientlyLazyCrypto.chm")
  
  addDirectoryToZip("#{package}/*.*", "#{$artifacts}/EfficientlyLazyCrypto.zip")
  
  rm_r(package)

end










