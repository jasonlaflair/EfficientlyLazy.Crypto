require 'RakeFileSettings'

def compile
  params = "/t:Rebuild /nologo /m /v:q /p:Configuration=#{@buildLevel}"
  
  # loop through in case of 2 sln files
  @solutionFiles.each do |solFile|
    sh "#{@msbuild} #{params} \"#{solFile}\""
  end
  
end

