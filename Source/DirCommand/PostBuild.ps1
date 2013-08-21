#echo $(SolutionDir)ILMerge.exe /out:$(SolutionDir)Out\$(TargetFileName) $(TargetDir)
#rmdir $(SolutionDir)Out /s /q
#mkdir $(SolutionDir)Out > nul
#copy $(TargetDir)$(TargetFileName) $(SolutionDir)Out\$(TargetFileName)

Param
(
  [string]$computerName,
  [string]$filePath
)

Write-Host "Foo!"