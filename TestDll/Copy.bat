del /Q BeforeInject\*
del /Q AfterInject\*

copy TestDll\TestDll\bin\Debug\TestDll.dll BeforeInject\TestDll.dll
copy TestDll\TestDll\bin\Debug\TestDll.pdb BeforeInject\TestDll.pdb
copy ..\IFix\IFix.Core.dll BeforeInject\IFix.Core.dll
copy ..\Library\process_cfg BeforeInject\process_cfg