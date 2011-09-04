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

task :default => :development

task :development => [:setBuildLevelDebug, :compile]
task :package => [:setBuildLevelRelease, :compile, :generateDocs, :packageup]

task :setBuildLevelDebug do
  $buildLevel = "Debug"
  $version = getVersion
end

task :setBuildLevelRelease do
  $buildLevel = "Release"
  $version = getVersion
end

task :compile do

    params = "/t:Clean /t:Rebuild /nologo /m /v:q /p:Configuration=#{$buildLevel}"
    
    # loop through in case of 2+ sln files
    $solutionFiles.each do |solFile|
      sh "#{$msbuild} #{params} \"#{solFile}\""
    end
end

  def self.getVersion

    versionFile = "#{$solutionRoot}/Source/SharedAssemblyInfo.cs"
    version = ""
    
    lines = ""
    File.open(versionFile, 'r') do |f|
        lines = f.readlines
      end

    lines.each do |line|
      if line.include?("AssemblyVersion")
        firstq = line.index('"') + 1
        lastq = line.index('"', firstq + 1)
        version = line[firstq, lastq - firstq]
      end
    end
    
    return version
    
  end

task :generateDocs do
  docFiles = FileList[$solutionRoot + "/Documentation/*.shfbproj"]
    
    params = "/nologo /m /v:q /p:Configuration=#{$buildLevel}"
    
    # loop through in case of 2+ sln files
    docFiles.each do |docFile|
      sh "#{$msbuild35} #{params} \"#{docFile}\""
    end
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

  folderv20 = "#{$artifacts}/Package/net20"
  mkdir(folderv20) unless File.exist?(folderv20)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazy.Crypto.v20/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv20)
  end
  
  mv("#{$artifacts}/EfficientlyLazy.Crypto.v20.chm", "#{folderv20}/EfficientlyLazy.Crypto.chm")

  folderv35 = "#{$artifacts}/Package/net35"
  mkdir(folderv35) unless File.exist?(folderv35)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazy.Crypto.v35/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv35)
  end

  mv("#{$artifacts}/EfficientlyLazy.Crypto.v35.chm", "#{folderv35}/EfficientlyLazy.Crypto.chm")
  
  folderv40 = "#{$artifacts}/Package/net40"
  mkdir(folderv40) unless File.exist?(folderv40)

  files = FileList["#{$solutionRoot}/Source/EfficientlyLazy.Crypto.v40/bin/Release/*.*"]
  files.each do |file|
    cp(file, folderv40)
  end

  mv("#{$artifacts}/EfficientlyLazy.Crypto.v40.chm", "#{folderv40}/EfficientlyLazy.Crypto.chm")

  zipfilename = "#{$artifacts}/EfficientlyLazy.Crypto-#{$version}.zip"
  
  rm(zipfilename) if File.exist?(zipfilename)
  
  create_zip(zipfilename, "#{package}")
  
  sh "nuget.exe pack ./EfficientlyLazy.Crypto.nuspec -outputDirectory ./Artifacts"
  
  rm_r(package)

end

def self.create_zip(new_zip_file, root)

require 'find'
  require 'zip/zip'
  
	Zip::ZipFile.open(new_zip_file, Zip::ZipFile::CREATE) do |zipfile|
		Find.find(root) do |path|
			Find.prune if File.basename(path)[0] == ?.
			dest = /Package\/(\w.*)/.match(path)
			zipfile.add(dest[1],path) if dest
		end
	end
  end








