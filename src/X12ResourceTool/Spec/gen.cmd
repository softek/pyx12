setlocal
where xsd.exe >nul
if errorlevel 1 set path=%path%;C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools
set args=/classes
set ns-prefix=/namespace:X12ResourceTool.Spec
xsd.exe ..\..\..\pyx12\map\codes.xsd    %args% %ns-prefix%
xsd.exe ..\..\..\pyx12\map\dataele.xsd  %args% %ns-prefix%
xsd.exe ..\..\..\pyx12\map\map.v2.xsd   %args% %ns-prefix%.MapV2
xsd.exe ..\..\..\pyx12\map\map.xsd      %args% %ns-prefix%.MapV1
xsd.exe ..\..\..\pyx12\map\maps.xsd     %args% %ns-prefix%
