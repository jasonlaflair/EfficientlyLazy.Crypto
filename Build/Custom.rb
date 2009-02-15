
def customMethods
  v2Files = "\"#{$solutionRoot}/Source/EfficientlyLazyCrypto.v20/bin/#{$buildLevel}/*\""
  helpFile = "\"#{$solutionRoot}/Documentation/EfficientlyLazyCrypto.v20/*.chm\""
  zipFile = "\"#{$rootBuildPath}/#{$buildLevel}.zip\""

  addDirectoryToZip(v2Files, zipFile)
  
  addFileToZip(helpFile, zipFile) if $buildLevel == $buildLevelRelease
  

  
end