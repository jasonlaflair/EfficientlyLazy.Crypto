
def runNCover
  puts "##teamcity[progressMessage 'Generating Coverage Reports']"
  
  sh "#{$nCover} /c:#{$nCoverConfig}"
end
