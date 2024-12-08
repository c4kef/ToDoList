#include <windows.h>

//Просто и со вкусом)
extern "C" __declspec(dllexport) void MyMessageBox(const char* message, const char* title) {
    MessageBoxA(NULL, message, title, MB_OK);
}