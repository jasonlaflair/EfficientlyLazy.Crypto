class MSBuild
  
  def self.compile

    params = "/t:Rebuild /nologo /m /v:q /p:Configuration=#{$buildLevel}"
    
    # loop through in case of 2+ sln files
    $solutionFiles.each do |solFile|
      sh "#{$msbuild} #{params} \"#{solFile}\""
    end
    
  end

  def self.getVersion

    versionFile = "#{$solutionRoot}/Source/SharedAssemblyInfo.cs"
    version = ""
    
    lines = ""
    File.open(versionFile, 'r') do |f|
        lines = f.readlines
      end

    lines.each do |line|
      if line.include?("AssemblyVersion")
        firstq = line.index('"') + 1
        lastq = line.index('"', firstq + 1)
        version = line[firstq, lastq - firstq]
      end
    end
    
    return version
    
  end
  
end
