require 'RakeFileSettings'

def buildDocumentationWithSandcastle configFile
  sh "\"#{@shfb}\" #{configFile}"
end

