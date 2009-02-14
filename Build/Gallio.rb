
def runUnitTests
    extension = '/e:TeamCityExtension,Gallio.TeamCityIntegration'
    options = '/runner:NCover2 /no-echo-results /wd:"' + @rootBuildPath + '"'
    
    unitTestAssmMask = FileList["#{@solutionRoot}/Tests/**/bin/#{@buildLevel}/*.Test.dll"]
    
    fileList = ''
    
    # wrap each path in quotes
    unitTestAssmMask.each do |p|
      fileList = fileList + '"' + p + '" '
    end
    
    sh "#{@GallioUnitTestRunner} #{extension} #{options} #{fileList}"
end
