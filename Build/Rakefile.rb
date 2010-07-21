$rootBuildPath = File.dirname(__FILE__)
$solutionRoot = File.dirname($rootBuildPath)
$artifacts = "#{$rootBuildPath}/Artifacts"

mkdir ($artifacts) unless File.exist?($artifacts)

$buildLevel = NIL

$msbuild = "\"C:/WINDOWS/Microsoft.NET/Framework/v4.0.30319/MSBuild.exe\""
$msbuild35 = "\"C:/WINDOWS/Microsoft.NET/Framework/v3.5/MSBuild.exe\""
$solutionFiles = FileList[$solutionRoot + "/*.sln"]

$nCoverExplorer = "\"c:/Program Files/NCover/NCoverExplorer.Console.exe\""
$nCoverConfig = "#{$rootBuildPath}/config.ncover"

$GallioEcho = "\"#{$solutionRoot}/ThirdParty/Gallio/Gallio.Echo.exe\""

$version = "0.0.0.0"

require "#{$rootBuildPath}/MSBuild.rb"
require "#{$rootBuildPath}/Gallio.rb"
require "#{$rootBuildPath}/NCover.rb"
require "#{$rootBuildPath}/SandCastle.rb"
require "#{$rootBuildPath}/ZipTools.rb"

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
  SandCastle.buildDocumentation
end

task :packageup do

  require "fileutils"
  
  package = "#{$artifacts}/Package"
  rm_r(package) if File.exist?(package)
  mkdir(package)

  folderDemo = "#{$artifacts}/Package/Demo"
  mkdir(folderDemo) unless File.exist?(folderDemo)
  
  files = FileList["#{$solutionRoot}/Source/EfficientlyLazy.Crypto.Demo/bin/Release/*.*"].exclude(/^.*vshost.*/, /^.*pdb/, /^.*xml/)
  files.each do |file|
    cp(file, folderDemo)
  end

  folderv20 = "#{$artifacts}/Package/v20"
  mkdir(folderv20) unless File.exist?(folderv20)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazy.Crypto.v20/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv20)
  end
  
  mv("#{$artifacts}/EfficientlyLazy.Crypto.v20.chm", "#{folderv20}/EfficientlyLazy.Crypto.chm")

  folderv35 = "#{$artifacts}/Package/v35"
  mkdir(folderv35) unless File.exist?(folderv35)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazy.Crypto.v35/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv35)
  end

  mv("#{$artifacts}/EfficientlyLazy.Crypto.v35.chm", "#{folderv35}/EfficientlyLazy.Crypto.chm")
  
  folderv40 = "#{$artifacts}/Package/v40"
  mkdir(folderv40) unless File.exist?(folderv40)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazy.Crypto.v40/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv40)
  end

  mv("#{$artifacts}/EfficientlyLazy.Crypto.v40.chm", "#{folderv40}/EfficientlyLazy.Crypto.chm")
  
  zipfilename = "#{$artifacts}/EfficientlyLazy.Crypto-#{$version}.zip"
  
  rm(zipfilename) if File.exist?(zipfilename)
  
  ZipTools.create_zip(zipfilename, "#{package}")
  
  rm_r(package)

end










