class SandCastle
    
  def self.buildDocumentation
    
    docFiles = FileList[$solutionRoot + "/Documentation/*.shfbproj"]
    
    params = "/nologo /m /v:q /p:Configuration=#{$buildLevel}"
    
    # loop through in case of 2+ sln files
    docFiles.each do |docFile|
      sh "#{$msbuild35} #{params} \"#{docFile}\""
    end
    
  end
    
end