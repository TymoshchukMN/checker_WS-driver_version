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
[string]$CheckDate = [datetime]::Now.Date.ToString("dd.MM.yyyy");
[string]$fileVersion = $null;

if([File]::Exists($filePath))
{
    $IsFileExists = $true;
    $fileVersion = [FileVersionInfo]::GetVersionInfo($filePath).FileVersion;
}

$uri = "http://172.16.0.54:7000/add";


$body = @{
    ComputerName =$env:COMPUTERNAME
    IsFileExists = $IsFileExists
    FileVersion = $FileVersion
    CheckDate = $CheckDate
} | ConvertTo-Json

$rand = [System.Random]::new();

[int16]$sleepSeconds = $rand.Next(0, 120);

$body
$sleepSeconds
# робимо для того, щоб усі одразу не надсилали данні
sleep -Seconds $sleepSeconds;

Invoke-RestMethod -Uri $uri -Method Put -Body $body -ContentType "application/json"