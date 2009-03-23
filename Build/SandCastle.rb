class SandCastle
  
  def self.buildDocumentation(solutionFile, framework, version, filename)

  parameters = "-vsimport=\"#{solutionFile}\""
  parameters += " -ProjectSummary=\"I need to come up with something creative here!!\""
  parameters += " -MissingTags=\"Summary, Parameter, Returns, Value, AutoDocumentCtors, Namespace, TypeParameter\""
  parameters += " -VisibleItems=\"InheritedMembers, InheritedFrameworkMembers, Protected, SealedProtected\""
  parameters += " -OutputPath=\"#{$artifacts}\""
  parameters += " -CleanIntermediates=True"
  parameters += " -KeepLogFile=False"
  parameters += " -HelpFileFormat=HtmlHelp1x"
  parameters += " -CppCommentsFixup=False"
  #parameters += " -FrameworkVersion=\"2.0.50727\""
  parameters += " -FrameworkVersion=\"#{framework}\""
  parameters += " -IndentHtml=False"
  parameters += " -Preliminary=True"
  parameters += " -RootNamespaceContainer=True"
  parameters += " -RootNamespaceTitle=EfficientlyLazyCrypto"
  parameters += " -HelpTitle=EfficientlyLazyCrypto"
  #parameters += " -HtmlHelpName=EfficientlyLazyCrypto"
  parameters += " -HtmlHelpName=#{filename}"
  parameters += " -Language=en-US"
  parameters += " -CopyrightText=\"LaFlair.NET 2009\""
  parameters += " -ProjectLinkType=Local"
  parameters += " -SdkLinkType=Msdn"
  parameters += " -SdkLinkTarget=Blank"
  parameters += " -PresentationStyle=vs2005"
  parameters += " -NamingMethod=HashedMemberName"
  parameters += " -SyntaxFilters=CSharp"
  parameters += " -ShowFeedbackControl=False"
  parameters += " -BinaryTOC=True"
  parameters += " -IncludeFavorites=False"
  parameters += " -CollectionTocStyle=Hierarchical"
  parameters += " -IncludeStopWordList=True"
  parameters += " -PlugInNamespaces=\"ms.vsipcc+, ms.vsexpresscc+\""
  #parameters += " -HelpFileVersion=\"0.0.9.0\""
  parameters += " -HelpFileVersion=\"#{version}\""
  parameters += " -ContentPlacement=AboveNamespaces"

  sh "\"#{$shfb}\" #{parameters}"

  end

end