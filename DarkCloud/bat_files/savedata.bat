@echo off

SET game=%1
SET localsave=%2
SET game_dir=%3
SET game_process=%4
SET date_string=%5

START "" %game_dir%

echo Waiting task...
timeout 5

cls

:LOOP
tasklist | find /i %game_process% >nul 2>&1
IF ERRORLEVEL 1 (
  GOTO PROGRAM_CLOSED
) ELSE (
  GOTO LOOP
)

:PROGRAM_CLOSED

echo Program closed, creating backup!

set PATH=%PATH%;%SystemDrive%\Program Files\7-Zip\
echo %PATH%

if %localsave%=="User Desktop" (7z a %SystemDrive%\Users\%username%\Desktop\%game%_backup_%date_string% %appdata%\%game%\*) ELSE (7z a %localsave%\%game%_backup%date_string% %appdata%\%game%\*)

echo DONE!

exit