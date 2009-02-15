$solutionRoot = Rake.original_dir
if $solutionRoot.include?('/Build')
  $solutionRoot = File.dirname($solutionRoot)
end

$rootBuildPath = Rake.original_dir
unless $rootBuildPath.include?('/Build')
  $rootBuildPath = $rootBuildPath + "/Build"
end

import "#{$rootBuildPath}/RakeFileSettings.rb"
import "#{$rootBuildPath}/MSBuild.rb"
import "#{$rootBuildPath}/NCover.rb"
import "#{$rootBuildPath}/Gallio.rb"
import "#{$rootBuildPath}/SandCastle.rb"
import "#{$rootBuildPath}/Custom.rb"

task :default => :development

task :development => [:setBuildLevelDebug, :compile, :runUnitTests, :runCoverage]
task :heavy => [:setBuildLevelDebug, :compile, :runUnitTests, :runCoverage]

task :qa => [:setBuildLevelQA, :compile, :runUnitTests, :runCoverage, :customMethods]
task :production => [:setBuildLevelRelease, :compile, :runUnitTests, :runCoverage, :generateDocs, :customMethods]

desc "do something funky"
task :setBuildLevelDebug do
  $buildLevel = $buildLevelDebug
end

task :setBuildLevelQA do
  $buildLevel = $buildLevelQA
end

task :setBuildLevelRelease do
  $buildLevel = $buildLevelRelease
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
  buildDocumentationWithSandcastle 'Documentation\\EfficientlyLazyCrypto.v20\\EfficientlyLazyCrypto.v20.shfb'
  buildDocumentationWithSandcastle 'Documentation\\EfficientlyLazyCrypto.v35\\EfficientlyLazyCrypto.v35.shfb'
end
  
task :customMethods do
  customMethods
end