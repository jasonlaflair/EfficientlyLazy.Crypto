
def addDirectoryToZip(quotedSourceDirectory, quotedZipFilePath)
  zipExe = "\"#{$rootBuildPath}/Tools/7zip/7za.exe\""
  
  params = "a -tzip -mx9 #{quotedZipFilePath} -ir!#{quotedSourceDirectory}"
  
  sh "#{zipExe} #{params}"
  
end

def addFileToZip(quotedSourceFile, quotedZipFilePath)
  zipExe = "\"#{$rootBuildPath}/Tools/7zip/7za.exe\""
  
  params = "a -tzip -mx9 #{quotedZipFilePath} #{quotedSourceFile}"
  
  sh "#{zipExe} #{params}"
  
end