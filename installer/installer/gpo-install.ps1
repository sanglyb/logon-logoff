Add-WindowsFeature RSAT-AD-PowerShell
Import-Module ActiveDirectory
Add-WindowsFeature GPMC
Remove-GPO logon-logoff-delete
$ScriptDir = Split-Path $script:MyInvocation.MyCommand.Path 
Import-GPO -BackupGpoName logon-logoff -Path $ScriptDir\logon-logoff-gpo -TargetName logon-logoff -CreateIfNeeded
$domain = Get-ADDomain
New-GPLink -Name logon-logoff -Target $domain.DistinguishedName
$logondomain = $env:LOGONSERVER+"\netlogon"
mkdir $logondomain\logon-logoff
$logondomain+="\logon-logoff"
copy ..\logon-class.dll $logondomain
copy ..\logon_agent.exe $logondomain
copy ..\logon_start_agent.exe $logondomain
copy ..\logon-logoff.config $logondomain
exit
