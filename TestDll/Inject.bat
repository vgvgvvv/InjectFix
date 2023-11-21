cd %~dp0
del /Q BeforeInject\*
del /Q AfterInject\*

copy TestDll\TestDll\bin\Debug\TestDll.dll BeforeInject\TestDll.dll
copy TestDll\TestDll\bin\Debug\TestDll.pdb BeforeInject\TestDll.pdb
copy ..\IFix\IFix.Core.dll BeforeInject\IFix.Core.dll
copy ..\Library\process_cfg BeforeInject\process_cfg

"C:\Program Files\Mono\bin\mono.exe" --debug --runtime=v4.0.30319  "../IFix/IFix.exe" ^
    "-inject" ^
    "BeforeInject\IFix.Core.dll" ^
    "BeforeInject\TestDll.dll" ^
    "no_cfg" ^
    "AfterInject\Test.ill.bytes" ^
    "AfterInject\TestDll.Injected.dll" ^
    "../IFix"