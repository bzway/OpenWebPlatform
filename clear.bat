echo Parameter��%1
echo ��ǰ�̷���%~d0
echo ��ǰ�̷���·����%~dp0
echo ��ǰ������ȫ·����%~f0
echo ��ǰ�̷���·���Ķ��ļ�����ʽ��%~sdp0
echo ��ǰCMDĬ��Ŀ¼��%cd%
echo Ŀ¼���пո�Ҳ���Լ���""�����Ҳ���·��
echo ��ǰ�̷���"%~d0"
echo ��ǰ�̷���·����"%~dp0"
echo ��ǰ������ȫ·����"%~f0"
echo ��ǰ�̷���·���Ķ��ļ�����ʽ��"%~sdp0"
echo ��ǰCMDĬ��Ŀ¼��"%cd%"

REM - performs a remove directory, with wildcard matching - example ; rd-wildcard 2007-*
dir BIN /b /s >loglist.txt
setlocal enabledelayedexpansion
for /f %%a in (./loglist.txt) do (
	rd /s /q %%a
)
del /q loglist.txt
endlocal

dir OBJ /b /s >loglist.txt
setlocal enabledelayedexpansion
for /f %%a in (./loglist.txt) do (
	rd /s /q %%a
)
del /q loglist.txt
endlocal
rd /s /q Publish
