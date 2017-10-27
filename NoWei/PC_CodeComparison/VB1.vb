VERSION 5.00
Begin VB.Form frmMain
   AutoRedraw = -1  'True
   Caption         = "N33 对码检测软件 V1.0"
   ClientHeight    = 5790
   ClientLeft      = 60
   ClientTop       = 450
   ClientWidth     = 11550
   KeyPreview      = -1  'True
   LinkTopic       = "Form1"
   ScaleHeight     = 386
   ScaleMode       = 3  'Pixel
   ScaleWidth      = 770
   StartUpPosition = 1  '所有者中心
   Begin VB.CommandButton cmdClear
      Caption         = "清屏"
      Height          = 372
      Left            = 1536
      TabIndex        = 16
      Top             = 4506
      Width           = 876
   End
   Begin VB.CommandButton cmdExit
      Caption         = "结束"
      Height          = 372
      Left            = 1536
      TabIndex        = 15
      Top             = 5040
      Width           = 876
   End
   Begin VB.ListBox lstInput
      BackColor       = &H80000006 &
      ForeColor = &H80000005 &
      Height = 4740
      Left            = 5952
      TabIndex        = 8
      Top             = 432
      Width           = 5172
   End
   Begin VB.CommandButton cmdFlush
      Cancel          = -1  'True
      Caption         = "清码"
      Height          = 372
      Left            = 384
      TabIndex        = 1
      Top             = 4506
      Width           = 876
   End
   Begin VB.CommandButton cmdMatchCode
      Caption         = "对码"
      Height          = 372
      Left            = 384
      TabIndex        = 0
      Top             = 5034
      Width           = 876
   End
   Begin VB.Label lblRxName
      AutoSize        = -1  'True
      Caption         = "接受器生产序列号"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 216
      Left            = 3744
      TabIndex        = 14
      Top             = 4080
      Width           = 1824
   End
   Begin VB.Label lblRxID
      Alignment       = 2  'Center
      BackColor       = &H80000005 &
      BorderStyle = 1  'Fixed Single
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 400
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Left            = 384
      TabIndex        = 13
      Top             = 4032
      Width           = 3072
   End
   Begin VB.Label lblTxName
      AutoSize        = -1  'True
      Caption         = "发射器生产序列号"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 216
      Left            = 3744
      TabIndex        = 12
      Top             = 3528
      Width           = 1824
   End
   Begin VB.Label lblTxID
      Alignment       = 2  'Center
      BackColor       = &H80000005 &
      BorderStyle = 1  'Fixed Single
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 400
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Left            = 384
      TabIndex        = 11
      Top             = 3504
      Width           = 3072
   End
   Begin VB.Label lblBVolt
      AutoSize        = -1  'True
      Caption         = "电池电压（V）"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 216
      Left            = 3744
      TabIndex        = 10
      Top             = 5112
      Width           = 1488
   End
   Begin VB.Label lblVolt
      Alignment       = 2  'Center
      BackColor       = &H80000005 &
      BorderStyle = 1  'Fixed Single
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 400
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Left            = 2688
      TabIndex        = 9
      Top             = 5088
      Width           = 732
   End
   Begin VB.Label lblKeys
      Alignment       = 2  'Center
      BorderStyle     = 1  'Fixed Single
      Caption         = "按键 6"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Index           = 5
      Left            = 4032
      TabIndex        = 7
      Top             = 1992
      Width           = 1188
   End
   Begin VB.Label lblKeys
      Alignment       = 2  'Center
      BorderStyle     = 1  'Fixed Single
      Caption         = "按键 5"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Index           = 4
      Left            = 4032
      TabIndex        = 6
      Top             = 1440
      Width           = 1188
   End
   Begin VB.Label lblKeys
      Alignment       = 2  'Center
      BorderStyle     = 1  'Fixed Single
      Caption         = "按键 4"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Index           = 3
      Left            = 1704
      TabIndex        = 5
      Top             = 2472
      Width           = 1188
   End
   Begin VB.Label lblKeys
      Alignment       = 2  'Center
      BorderStyle     = 1  'Fixed Single
      Caption         = "按键 3"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Index           = 2
      Left            = 1728
      TabIndex        = 4
      Top             = 1032
      Width           = 1188
   End
   Begin VB.Label lblKeys
      Alignment       = 2  'Center
      BorderStyle     = 1  'Fixed Single
      Caption         = "按键 2"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Index           = 1
      Left            = 2568
      TabIndex        = 3
      Top             = 1752
      Width           = 1188
   End
   Begin VB.Label lblKeys
      Alignment       = 2  'Center
      BorderStyle     = 1  'Fixed Single
      Caption         = "按键 1"
      BeginProperty Font
         Name            = "宋体"
         Size            = 10.5
         Charset         = 134
         Weight          = 700
         Underline       = 0   'False
         Italic          = 0   'False
         Strikethrough   = 0   'False
      EndProperty
      Height = 264
      Index           = 0
      Left            = 768
      TabIndex        = 2
      Top             = 1824
      Width           = 1188
   End
   Begin VB.Shape Shape1
      Height          = 2772
      Left            = 384
      Top             = 432
      Width           = 5172
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' N33 对码检测软件

' Copyright (C) 2011 KNORVAY
' AUTH: Neil
' DATE: 2012/05/28

' Description: Frame setting and Code Match

' V.1.0.0, 2012/05/28, by Neil
' 1. First Release.

Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
Private Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Long) As Integer

Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

Dim Scroll_Lock_On_Flag As Boolean
Dim Caps_Lock_On_Flag As Boolean
Dim Num_Lock_On_Flag As Boolean

Private Sub cmdExit_Click()

    DelHook

    End

End Sub

Private Sub cmdClear_Click()

    ' clear display
    lstInput.Clear
    lblTxID.Caption = ""
    lblRxID.Caption = ""
    lblVolt.Caption = ""

    ' set default label
    lblKeys(0).Caption = "按键 1"
    lblKeys(1).Caption = "按键 2"
    lblKeys(2).Caption = "按键 3"
    lblKeys(3).Caption = "按键 4"
    lblKeys(4).Caption = "按键 5"
    lblKeys(5).Caption = "按键 6"

    ' clear all 6 button backcolor
    For i = 0 To 5
        lblKeys(i).BackColor = &H8000000F
    Next

End Sub

Private Sub cmdFlush_Click()

    ' clear code list
    Clear_Match_Code

    ' clear display
    cmdClear_Click

End Sub

Private Sub cmdMatchCode_Click()

    ' 对码
    Set_Match_Code

    ' clear display
    cmdClear_Click

End Sub

Private Sub Form_Load()

    ' init variables
    Current_Bit = 0
    Mask_Input_Display = False

    Shift_Press_Flag = False
    Alt_Press_Flag = False

    Key_On_Define(0) = KEY_PGUP
    Key_On_Define(1) = KEY_PGDN
    Key_On_Define(2) = KEY_TAB
    Key_On_Define(3) = KEY_ENTER
    Key_On_Define(4) = KEY_F5
    Key_On_Define(5) = KEY_DOT

    ' 安装钩子
    AddHook

End Sub

Private Sub Form_Unload(Cancel As Integer)

    '卸钩子
    DelHook

End Sub

'安装钩子
Private Sub AddHook()

   '键盘钩子
   lHook = SetWindowsHookEx(WH_KEYBOARD_LL, AddressOf CallKeyHookProc, App.hInstance, 0)

End Sub

'卸钩子
Private Sub DelHook()

    UnhookWindowsHookEx lHook

End Sub

Private Sub Press_Caps_Lock()

    keybd_event 20, 0, 0, 0             ' DOWN
    Sleep 10                             ' delay for 10 mS
    keybd_event 20, 0, 2, 0             ' UP
    Sleep 50                             ' delay for 50 mS

End Sub

Private Sub Press_Scroll_Lock()

    keybd_event 145, 0, 0, 0            ' DOWN
    Sleep 10                            ' delay for 10 mS
    keybd_event 145, 0, 2, 0            ' UP
    Sleep 50                            ' delay for 50 mS

End Sub

Private Sub Press_Num_Lock()

    keybd_event 144, 0, 0, 0            ' DOWN
    Sleep 10                            ' delay for 10 mS
    keybd_event 144, 0, 2, 0            ' UP
    Sleep 50                            ' delay for 50 mS

End Sub

Private Sub Clear_Match_Code()

    ' Num Lock = 1, Caps Lock = 2, Scroll Lock = 4

    '卸钩子
    DelHook

    ' get current lock keys status
    If GetKeyState(KEY_SCROLL_LOCK) = 1 Then
        Scroll_Lock_On_Flag = True
    Else
        Scroll_Lock_On_Flag = False
    End If

    If GetKeyState(KEY_CAPS_LOCK) = 1 Then
        Caps_Lock_On_Flag = True
    Else
        Caps_Lock_On_Flag = False
    End If

    If GetKeyState(KEY_NUM_LOCK) = 1 Then
        Num_Lock_On_Flag = True
    Else
        Num_Lock_On_Flag = False
    End If

    ' 1, turn off all 3 keys, status = 0
    If Scroll_Lock_On_Flag = True Then  ' if SCROLL LOCK on, turn off
        Press_Scroll_Lock
    End If

    If Caps_Lock_On_Flag = True Then    ' if CAPS LOCK on, turn off
        Press_Caps_Lock
    End If

    If Num_Lock_On_Flag = True Then     ' if NUM LOCK on, turn off
        Press_Num_Lock
    End If

    Sleep 10                             ' delay for 10 mS

    ' 2, turn on SCROLL LOCK, NUM LOCK
    Press_Scroll_Lock
    Press_Num_Lock

    Sleep 10                            ' delay for 10 mS

    ' 3, turn off SCROLL LOCK
    Press_Scroll_Lock

    Sleep 10                            ' delay for 10 mS

    ' 4, turn on SCROLL LOCK
    Press_Scroll_Lock

    Sleep 10                            ' delay for 10 mS

    ' 5, turn off all keys
    Press_Scroll_Lock
    Press_Num_Lock

    ' 安装钩子
    AddHook

End Sub

Private Sub Set_Match_Code()

    ' Num Lock = 1, Caps Lock = 2, Scroll Lock = 4

    '卸钩子
    DelHook

    ' get current lock keys status
    If GetKeyState(KEY_SCROLL_LOCK) = 1 Then
        Scroll_Lock_On_Flag = True
    Else
        Scroll_Lock_On_Flag = False
    End If

    If GetKeyState(KEY_CAPS_LOCK) = 1 Then
        Caps_Lock_On_Flag = True
    Else
        Caps_Lock_On_Flag = False
    End If

    If GetKeyState(KEY_NUM_LOCK) = 1 Then
        Num_Lock_On_Flag = True
    Else
        Num_Lock_On_Flag = False
    End If

    ' 1, turn off all 3 keys, status = 0
    If Scroll_Lock_On_Flag = True Then  ' if SCROLL LOCK on, turn off
        Press_Scroll_Lock
    End If

    If Caps_Lock_On_Flag = True Then    ' if CAPS LOCK on, turn off
        Press_Caps_Lock
    End If

    If Num_Lock_On_Flag = True Then     ' if NUM LOCK on, turn off
        Press_Num_Lock
    End If

    Sleep 50                             ' delay for 50 mS

    ' 2, turn on CAPS LOCK,SCROLL LOCK, NUM LOCK, status = 7
    Press_Caps_Lock
    Press_Scroll_Lock
    Press_Num_Lock

    ' 3, turn off CAPS LOCK, SCROLL LOCK, status = 1
    Press_Caps_Lock
    Press_Scroll_Lock

    ' 4, turn on Caps LOCK, SCROLL LOCK, status = 7
    Press_Caps_Lock
    Press_Scroll_Lock

    ' 5, turn off all 3 keys, status = 0

    Sleep 50                            ' delay for 50 mS

    Press_Caps_Lock
    Press_Scroll_Lock
    Press_Num_Lock

    ' 安装钩子
    AddHook

End Sub

