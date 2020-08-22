$ErrorActionPreference = 'Stop';
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"


$archive = Join-Path $toolsDir "MPos.zip"
Get-ChocolateyUnzip -FileFullPath $archive -Destination $toolsDir -PackageName $env:ChocolateyPackageName

$targetDir = Join-Path $toolsDir "MPos"
$target =  Join-Path $targetDir "MPos.exe"
Install-ChocolateyShortcut -shortcutFilePath "$([Environment]::GetFolderPath('CommonStartMenu'))\Programs\Bluegrams\MPos.lnk" -targetPath $target -workingDirectory $targetDir

New-Item -Path "$target.gui" -ItemType File -Force | Out-Null
