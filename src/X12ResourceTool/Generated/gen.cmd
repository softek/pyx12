setlocal
where xsd.exe >nul
if errorlevel 1 set path=%path%;C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools
xsd.exe ..\..\..\pyx12\map\codes.xsd    /classes
xsd.exe ..\..\..\pyx12\map\dataele.xsd  /classes
xsd.exe ..\..\..\pyx12\map\map.v2.xsd   /classes
xsd.exe ..\..\..\pyx12\map\map.xsd      /classes
xsd.exe ..\..\..\pyx12\map\maps.xsd     /classes
