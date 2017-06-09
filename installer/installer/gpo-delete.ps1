Add-WindowsFeature RSAT-AD-PowerShell
Import-Module ActiveDirectory
Add-WindowsFeature GPMC
Remove-GPO logon-logoff
$ScriptDir = Split-Path $script:MyInvocation.MyCommand.Path 
Import-GPO -BackupGpoName logon-logoff-delete -Path $ScriptDir\logon-logoff-delete -TargetName logon-logoff-delete -CreateIfNeeded
$domain = Get-ADDomain
New-GPLink -Name logon-logoff-delete -Target $domain.DistinguishedName
$logondomain = $env:LOGONSERVER
Remove-Item -Recurse -Force $logondomain\netlogon\logon-logoff
exit
