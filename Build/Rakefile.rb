import Rake.original_dir + '/RakeFileSettings.rb'

import Rake.original_dir + '/MSBuild.rb'
import Rake.original_dir + '/NCover.rb'
import Rake.original_dir + '/Gallio.rb'
import Rake.original_dir + '/SandCastle.rb'
import Rake.original_dir + '/Custom.rb'

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