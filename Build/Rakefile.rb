@rootBuildPath = Rake.original_dir

unless @rootBuildPath.include?('/Build')
  @rootBuildPath = @rootBuildPath + "/Build"
end

import @rootBuildPath + '/RakeFileSettings.rb'
import @rootBuildPath + '/MSBuild.rb'
import @rootBuildPath + '/NCover.rb'
import @rootBuildPath + '/Gallio.rb'
import @rootBuildPath + '/SandCastle.rb'
import @rootBuildPath + '/Custom.rb'

task :default => :development

task :test => [:setDebugLevel, :runCoverage]

task :development => [:setDebugLevel, :compile, :runUnitTests]
task :heavy => [:setDebugLevel, :compile, :runUnitTests, :runCoverage]

task :qa => [:setQALevel, :compile, :runUnitTests, :runCoverage, :customMethods]
task :production => [:compileRelease, :compile, :runUnitTests, :runCoverage, :generateDocs, :customMethods]

task :setDebugLevel do
  @buildLevel = 'Debug'
end

task :setQALevel do
  @buildLevel = 'Debug'
end

task :setProductionLevel do
  @buildLevel = 'Release'
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