Properties { 
  $base_dir  = resolve-path .
  $sln_file = "$base_dir\..\efficientlylazycrypto.sln"
  $sln_config = "Release"
  $version = "0.9.2.0"
} 

$framework = '4.0'

include .\psake_ext.ps1

task default -depends Compile

task Init {
Generate-Assembly-Info `
		-file "$base_dir\..\Source\SharedAssemblyInfo.cs" `
		-description "Simplifying .NET Cryptography" `
		-company "LaFlair.NET" `
		-product "EfficientlyLazy.Crypto for .NET" `
		-version $version `
		-copyright "Copyright © Jason LaFlair & LaFlair.NET 2009-2011"
}

task Compile -depends Clean {
	Exec { msbuild "$sln_file" /t:Rebuild /nologo /m /v:q /p:Configuration="$sln_config" }
}

task BuildDocs -depends Compile {
	Exec { msbuild "$base_dir\..\Documentation\EfficientlyLazy.Crypto.v20.shfbproj" /nologo /m /v:q /p:Configuration="$sln_config" }
	Exec { msbuild "$base_dir\..\Documentation\EfficientlyLazy.Crypto.v35.shfbproj" /nologo /m /v:q /p:Configuration="$sln_config" }
	Exec { msbuild "$base_dir\..\Documentation\EfficientlyLazy.Crypto.v40.shfbproj" /nologo /m /v:q /p:Configuration="$sln_config" }
}

task Clean -depends Init {
	Exec { msbuild "$sln_file" /t:Clean /nologo /m /v:q /p:Configuration="$sln_config" }
}

task UnitTests -depends Compile {
	if ((Get-PSSnapin Gallio -ErrorAction SilentlyContinue) -eq $null)
	{
		Add-PsSnapin Gallio
	}

	Run-Gallio "..\Tests\EfficientlyLazy.Crypto.v20.Test\bin\Release\EfficientlyLazy.Crypto.Test.dll", `
				"..\Tests\EfficientlyLazy.Crypto.v35.Test\bin\Release\EfficientlyLazy.Crypto.Test.dll", `
				"..\Tests\EfficientlyLazy.Crypto.v40.Test\bin\Release\EfficientlyLazy.Crypto.Test.dll"
}