
def compile
  puts "##teamcity[progressMessage '#{$buildLevel} Build']"
  
  params = "/t:Rebuild /nologo /m /v:q /p:Configuration=#{$buildLevel}"
  
  # loop through in case of 2 sln files
  $solutionFiles.each do |solFile|
    sh "#{$msbuild} #{params} \"#{solFile}\""
  end
  
end

