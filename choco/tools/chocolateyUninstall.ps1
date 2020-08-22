$ErrorActionPreference = 'Stop';

Remove-Item "$([Environment]::GetFolderPath('CommonStartMenu'))\Programs\Bluegrams\MPos.lnk"
