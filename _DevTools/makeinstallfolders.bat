@echo off

rem Make doctcod installation folders
rem Copyright (c) Davide Gironi, 2020

rem set destination path
set DESTPATH=Working\%1

move "%DESTPATH%\DoctcoD" "%DESTPATH%\Bin"
move "%DESTPATH%\Bin\www" "%DESTPATH%\www"
if not exist "%DESTPATH%\DoctcoD" mkdir "%DESTPATH%\DoctcoD"
move "%DESTPATH%\Bin" "%DESTPATH%\DoctcoD\Bin"
move "%DESTPATH%\License" "%DESTPATH%\DoctcoD\Bin\"
move "%DESTPATH%\www" "%DESTPATH%\DoctcoD-www"
move "%DESTPATH%\_DBDump" "%DESTPATH%\Install\"
if not exist "%DESTPATH%\DoctcoD\Data" mkdir "%DESTPATH%\DoctcoD\Data"
if not exist "%DESTPATH%\DoctcoD\Data\Attachments" mkdir "%DESTPATH%\DoctcoD\Data\Attachments"
if not exist "%DESTPATH%\DoctcoD\Data\Datas" mkdir "%DESTPATH%\DoctcoD\Data\Datas"
if not exist "%DESTPATH%\DoctcoD\Data\Invoices" mkdir "%DESTPATH%\DoctcoD\Data\Invoices"
if not exist "%DESTPATH%\DoctcoD\Temp" mkdir "%DESTPATH%\DoctcoD\Temp"

exit
