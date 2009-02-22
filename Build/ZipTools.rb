
def addDirectoryToZip(sourceDirectory, zipFilePath)
  
  zipExe = "\"#{$rootBuildPath}/Tools/7zip/7za.exe\""
  
  params = "a -tzip -mx9 \"#{zipFilePath}\" -ir!\"#{sourceDirectory}\""
  
  sh "#{zipExe} #{params}"
  
end

def addFileToZip(sourceFile, zipFilePath)
  
  zipExe = "\"#{$rootBuildPath}/Tools/7zip/7za.exe\""
  
  params = "a -tzip -mx9 \"#{zipFilePath}\" \"#{sourceFile}\""
  
  sh "#{zipExe} #{params}"
  
end
