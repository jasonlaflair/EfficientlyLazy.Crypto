
def runNCover
  sh "#{$nCover} /c:#{$nCoverConfig}"
end
