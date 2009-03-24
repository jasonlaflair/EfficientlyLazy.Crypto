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

$shfb64 = "C:/Program Files (x86)/EWSoftware/Sandcastle Help File Builder/SandcastleBuilderConsole.exe"
$shfb32 = "C:/Program Files/EWSoftware/Sandcastle Help File Builder/SandcastleBuilderConsole.exe"
$shfb = ""

$version = "0.0.0.0"

require "#{$rootBuildPath}/MSBuild.rb"
require "#{$rootBuildPath}/Gallio.rb"
require "#{$rootBuildPath}/NCover.rb"
require "#{$rootBuildPath}/SandCastle.rb"
require "#{$rootBuildPath}/ZipTools.rb"

task :test do
  
  
end


task :default => :development

task :development => [:setBuildLevelDebug, :compile, :runUnitTests, :runCoverage]
task :package => [:setBuildLevelRelease, :compile, :generateDocs, :packageup]

task :setBuildLevelDebug do
  $buildLevel = "Debug"
  $version = MSBuild.getVersion
end

task :setBuildLevelRelease do
  $buildLevel = "Release"
  $version = MSBuild.getVersion
end

task :compile do
  MSBuild.compile
end

task :runUnitTests do
  Gallio.runUnitTests
end

task :runCoverage do
  NCover.runNCover
end

task :generateDocs do
  
  $shfb = $shfb32 if File.exist?($shfb32)
  $shfb = $shfb64 if File.exist?($shfb64)
  
  if ($shfb == "")
    puts "Unable to find Sandcastle Help File Builder"
    exit
  end
  
  SandCastle.buildDocumentation("#{$solutionRoot}/Source/EfficientlyLazyCrypto.v20/EfficientlyLazyCrypto.v20.csproj", "2.0.50727", $version, "EfficientlyLazyCrypto.v20")
  SandCastle.buildDocumentation("#{$solutionRoot}/Source/EfficientlyLazyCrypto.v35/EfficientlyLazyCrypto.v35.csproj", "3.5", $version, "EfficientlyLazyCrypto.v35")
  
end

task :packageup do

  require "fileutils"
  
  package = "#{$artifacts}/Package"
  rm_r(package) if File.exist?(package)
  mkdir(package)
  
  folderv20 = "#{$artifacts}/Package/v20"
  mkdir(folderv20) unless File.exist?(folderv20)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazyCrypto.v20/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv20)
  end
  
  mv("#{$artifacts}/EfficientlyLazyCrypto.v20.chm", "#{folderv20}/EfficientlyLazyCrypto.chm")

  folderv35 = "#{$artifacts}/Package/v35"
  mkdir(folderv35) unless File.exist?(folderv35)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazyCrypto.v35/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv35)
  end

  mv("#{$artifacts}/EfficientlyLazyCrypto.v35.chm", "#{folderv35}/EfficientlyLazyCrypto.chm")
  
  zipfilename = "#{$artifacts}/EfficientlyLazyCrypto-#{$version}.zip"
  
  rm(zipfilename) if File.exist?(zipfilename)
  
  ZipTools.create_zip(zipfilename, "#{package}/")
  
  rm_r(package)

end










