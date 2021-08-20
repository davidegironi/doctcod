
#solution name to build
$solutionName = "DoctcoD"

#set version
$versionMajor = "1"
$versionMinor = "0"
$versionBuild = GetVersionBuild
$versionRevision = "2"
#build version number
$version = GetVersion $versionMajor $versionMinor $versionBuild $versionRevision

#base folder for of the solution
$baseDir  = Resolve-Path .\..\

#release folder for of the solution
$releaseDir = Resolve-Path .\..\..\Release

#builder parameters
$buildDebugAndRelease = $false
$treatWarningsAsErrors = $true
$releaseDebugFiles = $false

#remove elder release builds for the actual version
$removeElderReleaseWithSameVersion = $true

#folders and files to exclude from the packaged release Source
$releaseSrcExcludeFolders = @('"_DevTools"', '".git"');
$releaseSrcExcludeFiles = @('".git*"');

#builds array
#include here all the solutions file to build	
$builds = @(
	@{
		#solutions filename (.sln)
		Name = "DoctcoD";
		#msbuild optionals constants
		Constants = "";
		#projects to exclude from the release binary package
		ReleaseBinExcludeProjects = @(
			@{
				Name = "DoctcoDModel";
			},
			@{
				Name = "DoctcoDModel.Test";
			},
			@{
				Name = "DoctcoDPopulateTestDatabase";
			},
			@{
				Name = "DoctcoDPrintModelDefault";
			},
			@{
				Name = "DoctcoDPrintModel01";
			},
			@{
				Name = "DoctcoDHelpers";
			},
			@{
				Name = "DoctcoDHelpers.Test";
			},
			@{
				Name = "DoctcoDSer";
			}
		);
		#files to include in the release binary package
		ReleaseBinIncludeFiles = @();
		#unit tests to run
		Tests = @(
			@{
				Name = "DoctcoDModel.Test"
			},
			@{
				Name = "DoctcoDHelpers.Test"
			}
		);
		#commands to run before packaging of the release source
		ReleaseSrcCmd = @(
			@{
				Cmd = ".\cleandatafolders.bat"
			},
			@{
				Cmd = ".\dbsql-backuptsql.bat ..\..\"
			},
			@{
				Cmd = ".\dbsql-backupsqlschema.bat ..\..\"
			},
			@{
				Cmd = "xcopy ..\..\_DBDump\* Working\Src\_DBDump\ /s /e /y"
			}
		);
		#commands to run before packaging of the release source
		ReleaseBinCmd = @(
			@{
				Cmd = ".\cleandatafolders.bat"
			},
			@{
				Cmd = ".\dbsql-backuptsqlempty.bat Bin"
			},
			@{
				Cmd = ".\dbsql-backupsqlschema.bat Bin"
			},
			@{
				Cmd = ".\copydocuments.bat Bin"
			},
			@{
				Cmd = ".\copylicense.bat"
			},
			@{
				Cmd = ".\makeinstallfolders.bat Bin"
			}
		);
	};
)