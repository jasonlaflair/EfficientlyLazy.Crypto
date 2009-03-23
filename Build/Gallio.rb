class Gallio
  
  def self.runUnitTests

    extension = "" #"/e:TeamCityExtension,Gallio.TeamCityIntegration"
    options = "/runner:NCover2 /no-echo-results /rt:HTML /rnf:UnitTestResults /rd:\"#{$artifacts}\" /wd:\"#{$artifacts}\""

    unitTestAssmMask = FileList["#{$solutionRoot}/Tests/**/bin/#{$buildLevel}/*.Test.dll"]

    fileList = ""

    # wrap each path in quotes
    unitTestAssmMask.each do |p|
      fileList = fileList + "\"" + p + "\" "
    end
    
    sh "#{$GallioEcho} #{extension} #{options} #{fileList}"
    
  end
  
end