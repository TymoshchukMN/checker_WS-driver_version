<#
    -- =============================================
    -- Author:		TymoshchukMN
    -- Create date: 03.07.2026
    -- Description:	Check version of WS_Drivers and send via api
    -- =============================================
#>

using namespace System.IO;
using namespace System.Diagnostics;

[string]$filePath = "C:\swsetup\Comfy_WS_Service\WS_Drivers.exe";
[bool]$IsFileExists = $false;
[string]$ckeckDate = [datetime]::Now.Date.ToString("dd.MM.yyyy");
[string]$fileVersion = $null;

if([File]::Exists($filePath))
{
    $IsFileExists = $true;
    $fileVersion = [FileVersionInfo]::GetVersionInfo($filePath).FileVersion;
}


$uri = "http://172.16.0.54:7000/add";

$body = @{
    ComputerName =$env:COMPUTERNAME
    IsFileExists = $ІsFileWxists
    FileVersion = $FileVersion
    CkeckDate = $ckeckDate
} | ConvertTo-Json

Invoke-RestMethod -Uri $uri -Method Post -Body $body -ContentType "application/json"