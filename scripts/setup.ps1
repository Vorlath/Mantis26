param (
    [switch] $UpdateGit,
    [switch] $BuildAnalyzers,
    [switch] $BuildMonoGame
)

Write-Host "Installing Mantis26..." -ForegroundColor Gray
Write-Host "UpdateGit: $UpdateGit" -ForegroundColor ($($UpdateGit ? 'Green' : 'Red'))
Write-Host "BuildAnalyzers: $BuildAnalyzers" -ForegroundColor ($($BuildAnalyzers ? 'Green' : 'Red'))
Write-Host "BuildMonoGame: $BuildMonoGame" -ForegroundColor ($($BuildMonoGame ? 'Green' : 'Red'))

$WorkingDirectory = Get-Location;
Set-Location $PSScriptRoot;

if($UpdateGit)
{
    Write-Host "Updating Git submodules..." -ForegroundColor Gray
    git submodule update --init --recursive
}

# Invoke the Guppy Install script
$mantisParams = @{}
if ($BuildAnalyzers) { $mantisParams["BuildAnalyzers"] = $true }
if ($BuildMonoGame)   { $mantisParams["BuildMonoGame"]   = $true }
$scriptPath = Join-Path $PSScriptRoot "../libraries/Mantis/scripts/install.ps1"
& $scriptPath @mantisParams

$SolutionDirectory = "$($PSScriptRoot)/.." | Resolve-Path
$NugetDirectory = "$($SolutionDirectory)/libraries/Mantis/.nuget"

@'
<!-- Generated via Mantis/scripts/install.ps1 -->
<configuration>
  <packageSources>
    <add key="MantisPackages" value="{0}" />
  </packageSources>
</configuration>
'@ -f $NugetDirectory | Out-File -FilePath "$($SolutionDirectory)/nuget.config"