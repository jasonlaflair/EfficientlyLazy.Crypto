
def runNCover

  #generateAndRun("FullCoverageReport")
  generateAndRun("ModuleSummary")
  generateAndRun("ModuleMethodSummary")
  generateAndRun("ModuleNamespaceSummary")
  generateAndRun("ModuleClassSummary")
  generateAndRun("ModuleClassFunctionSummary")
  generateAndRun("ModuleMethodFunctionSummary")

end

def generateAndRun(reportType)
  configFile = createConfigFile(reportType)
  sh "#{$nCoverExplorer} /c:\"#{configFile}\""
  rm(configFile)
end

def createConfigFile(reportType)
  lines = ""
  File.open($nCoverConfig, 'r') do |f|
      lines = f.readlines
  end
  
  newConfig = "#{$artifacts}/#{reportType}.config"
  
  File.open(newConfig, 'w') do |content|
    lines.each do |line|
      line.gsub!("@REPORTTYPE@", "#{reportType}")
      content.puts line
    end
  end
  
  return newConfig
end
