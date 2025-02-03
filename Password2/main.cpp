#include "mainwindow.h"
#include <qrect.h>
#include <qscreen.h>
#include <QApplication>
#include <QCoreApplication>
#include <iostream>
#include <QDebug>
#include <Windows.h>
#pragma comment(lib, "user32.lib")

HHOOK hHook=NULL;
void UpdateKeyState(BYTE *keystate, int keycode)
{
    keystate[keycode]=GetKeyState(keycode);
}

LRESULT CALLBACK MyLowLevelKeyBoardProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    qDebug()<<"Key Pressed";
    KBDLLHOOKSTRUCT cKey = *((KBDLLHOOKSTRUCT*)lParam);
    static bool KeyStroke;
    static KBDLLHOOKSTRUCT *p;
    if (nCode < 0) return CallNextHookEx(NULL, nCode, wParam, lParam);
    KeyStroke = FALSE;
    if (nCode == HC_ACTION)
    {
        switch(wParam)
        {
        case WM_KEYDOWN:
        case WM_SYSKEYDOWN:
        case WM_KEYUP:
        case WM_SYSKEYUP:
            p = (KBDLLHOOKSTRUCT *)lParam;
            KeyStroke = ((p->vkCode == VK_LWIN) || (p->vkCode == VK_RWIN)) ||
                    ((p->vkCode == VK_TAB) && ((p->flags & LLKHF_ALTDOWN)!=0)) ||
                    ((p->vkCode == VK_ESCAPE) && ((p->flags & LLKHF_ALTDOWN)!=0)) ||
                    ((p->vkCode == VK_ESCAPE) && ((GetKeyState(VK_CONTROL) & 0x8000)!=0)) ||
              //      ((p->vkCode ==VK_F4) && ((p->flags & LLKHF_ALTDOWN)!=0)) ||
                    ((p->vkCode ==0xC0) && ((MOD_CONTROL +  0x10)!=0));
            break;
        default:
            break;
        }
    }
    if (KeyStroke)
        return 777;
    else
        return CallNextHookEx(hHook, nCode, wParam, lParam);
}

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow w;

    QSize size=qApp->screens()[0]->size();
    hHook=SetWindowsHookExA(WH_KEYBOARD_LL,MyLowLevelKeyBoardProc,NULL,0);
    if(hHook == NULL)
    {
        qDebug()<<"Hook faild";
    }

 //   w.setWindowState(Qt::WindowFullScreen);
    w.show();
    w.move(0, size.height() - 360);
    return a.exec();
}
