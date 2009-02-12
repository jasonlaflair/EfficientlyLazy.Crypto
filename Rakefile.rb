@msbuild = 'C:\\WINDOWS\\Microsoft.NET\\Framework\\v3.5\\MSBuild.exe'
@shfb = 'C:\\Program Files (x86)\\EWSoftware\\Sandcastle Help File Builder\\SandcastleBuilderConsole.exe'
@packageLib20 = 'Package\\lib\\v20\\'
@packageLib35 = 'Package\\lib\\v35\\'
@packageDemo = 'Package\\Demo\\'

task :default => :build

task :build => [:compileDebug, :runTests]
task :release => [:compileRelease, :releaseFiles, :generateDocs]

task :compileDebug do
  params = '/t:Rebuild /nologo /m:2 /v:m /p:Configuration=Debug efficientlylazycrypto.sln'
  sh "#{@msbuild} #{params}"
end

task :compileRelease do
  params = '/t:Rebuild /nologo /m:2 /v:m /p:Configuration=Release efficientlylazycrypto.sln'
  sh "#{@msbuild} #{params}"
end

task :runTests do
 runner = 'ThirdParty\\Gallio\\Gallio.Echo.exe'
 assemblies = FileList["Tests/**/bin/Debug/*.Test.dll"]
 extension = '/e:TeamCityExtension,Gallio.TeamCityIntegration'
 options = '' # '/runner:NCover2'
 sh "#{runner} #{assemblies} #{extension} #{options}"
end

task :releaseFiles do
  source20 = 'Source\\EfficientlyLazyCrypto.v20\\bin\\Release\\*.*'
  sh "xcopy /q/y #{source20} #{@packageLib20}"
  
  source35 = 'Source\\EfficientlyLazyCrypto.v35\\bin\\Release\\*.*'
  sh "xcopy /q/y #{source35} #{@packageLib35}"
  
  demo20 = 'Source\\EfficientlyLazyCrypto.Demo\\bin\\Release\\*.*'
  sh "xcopy /q/y #{demo20} #{@packageDemo}"
  
  sh "del #{@packageDemo}*.vshost.*"
  sh "del #{@packageDemo}*.pdb"
  
  end

task :generateDocs do
  config20 = 'Documentation\\EfficientlyLazyCrypto.v20\\EfficientlyLazyCrypto.v20.shfb'
  sh "\"#{@shfb}\" #{config20}"
  
  chm20 = 'Documentation\\EfficientlyLazyCrypto.v20\\EfficientlyLazyCrypto.chm'
  sh "xcopy #{chm20} #{@packageLib20}"
  
  config35 = 'Documentation\\EfficientlyLazyCrypto.v35\\EfficientlyLazyCrypto.v35.shfb'
  sh "\"#{@shfb}\" #{config35}"

  chm35 = 'Documentation\\EfficientlyLazyCrypto.v35\\EfficientlyLazyCrypto.chm'
  sh "xcopy #{chm35} #{@packageLib35}"
 
 end
  