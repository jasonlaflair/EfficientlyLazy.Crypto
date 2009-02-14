
def runNCover
  sh "#{@nCover} /c:#{@nCoverConfig} /e"
end
