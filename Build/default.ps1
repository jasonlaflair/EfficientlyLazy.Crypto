Properties { 
  $base_dir  = resolve-path .
  $sln_file = "$base_dir\..\src\EfficientlyLazy.Crypto.sln"
  $sln_config = "Release"
  $version = "0.9.4.0"
  $release_dir = "$base_dir\Release"
}

$framework = '4.0'

include .\psake_ext.ps1

task default -depends Package

task Init {
	Generate-Assembly-Info `
		-file "$base_dir\..\src\SharedAssemblyInfo.cs" `
		-description "Simplifying .NET Cryptography" `
		-company "LaFlair.NET" `
		-product "EfficientlyLazy.Crypto for .NET" `
		-version $version `
		-copyright "Copyright © LaFlair.NET 2009-2012"
		
	remove-item -force -recurse $release_dir -ErrorAction SilentlyContinue 	
	new-item "$release_dir" -itemType directory
}

task Clean -depends Init {
	Exec { msbuild "$sln_file" /t:Clean /nologo /m /v:q /p:Configuration="$sln_config" }
}

task Compile -depends Clean {
	Exec { msbuild "$sln_file" /t:Rebuild /nologo /m /v:q /p:Configuration="$sln_config" }
}

task UnitTests -depends Compile {
	#if ((Get-PSSnapin Gallio -ErrorAction SilentlyContinue) -eq $null)
	#{
	#	Add-PsSnapin Gallio
	#}

	#Run-Gallio -NoProgress "..\src\EfficientlyLazy.Crypto.Tests\bin\$sln_config\EfficientlyLazy.Crypto.Test.dll"
	
	#if ($lastExitCode -ne 0) {
    #    throw "Error: Unit Tests Failed!"
    #}
}

task BuildDocs -depends UnitTests {
	Exec { msbuild "$base_dir\..\doc\EfficientlyLazy.Crypto.shfbproj" /nologo /m /v:q /p:Configuration="$sln_config" }
}

task CopyFiles -depends BuildDocs { 
	cp "..\src\EfficientlyLazy.Crypto\bin\$sln_config\EfficientlyLazy.Crypto.*" "$release_dir"
	cp "..\src\EfficientlyLazy.Crypto.Demo\bin\$sln_config\EfficientlyLazy.Crypto.Demo.exe" "$release_dir"
	cp "..\doc\build\EfficientlyLazy.Crypto.chm" "$release_dir"
}

task BuildNugetPackage -depends CopyFiles  {
	& "$base_dir\nuget.exe" pack "$base_dir\EfficientlyLazy.Crypto.nuspec" -outputdirectory "$release_dir" -version $version
}

task Package -depends BuildNugetPackage {
	& $base_dir\7za.exe a `
		"$release_dir\EfficientlyLazy.Crypto.$version.zip" `
		"$release_dir\EfficientlyLazy.Crypto.dll" `
		"$release_dir\EfficientlyLazy.Crypto.xml" `
		"$release_dir\EfficientlyLazy.Crypto.Demo.exe" `
		"$release_dir\EfficientlyLazy.Crypto.chm" `
		-mx=9
	
	remove-item "$release_dir\EfficientlyLazy.Crypto.dll"
	remove-item "$release_dir\EfficientlyLazy.Crypto.xml"
	remove-item "$release_dir\EfficientlyLazy.Crypto.Demo.exe"
	remove-item "$release_dir\EfficientlyLazy.Crypto.chm"
}














