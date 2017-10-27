Attribute VB_Name = "Module1"
' Hook.BAS

' Copyright (C) 2011 KNORVAY
' AUTH: Neil
' DATE: 2012/05/28

' Description: Handle of Keyboard hook

' V.1.0.0, 2012/05/28, by Neil
' 1. First Release.

Public Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Long, ByVal lpfn As Long, ByVal hmod As Long, ByVal dwThreadId As Long) As Long
Public Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Long) As Long
Public Declare Function GetKeyNameText Lib "user32" Alias "GetKeyNameTextA" (ByVal lParam As Long, ByVal lpBuffer As String, ByVal nSize As Long) As Long
Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (lpvDest As Any, ByVal lpvSource As Long, ByVal cbCopy As Long)

Public Const WH_KEYBOARD = 2
Public Const WH_KEYBOARD_LL = 13

'键盘消息
Public Const WM_KEYDOWN = &H100
Public Const WM_KEYUP = &H101
Public Const WM_SYSKEYDOWN = &H104
Public Const WM_SYSKEYUP = &H105

Public Type KEYMSGS
        vKey As Long           '虚拟码   (and &HFF)
        sKey As Long           '扫描码
        flag As Long           '键按下：128 抬起：0
        time As Long           'Window运行时间
End Type

' 键盘虚拟码
Public Const KEY_TAB = 9
Public Const KEY_ENTER = 13
Public Const KEY_CAPS_LOCK = 20
Public Const KEY_ESC = 27
Public Const KEY_PGUP = 33
Public Const KEY_PGDN = 34
Public Const KEY_P = 80
Public Const KEY_T = 84
Public Const KEY_F4 = 115
Public Const KEY_F5 = 116
Public Const KEY_NUM_LOCK = 144
Public Const KEY_SCROLL_LOCK = 145
Public Const KEY_L_SHIFT = 160
Public Const KEY_L_ALT = 164
Public Const KEY_DOT = 190

Public lHook As Long

Public keyMsg As KEYMSGS

Public Mask_Input_Display As Boolean

Public Current_Bit As Integer
Public Key_On_Define(5) As Integer

Public Input_Key(80) As Long

Public strKeyName As String * 255
Public strLen As Long

Public Shift_Press_Flag As Boolean
Public Alt_Press_Flag As Boolean

'键盘钩子
Public Function CallKeyHookProc(ByVal nCode As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
     
    Dim i As Integer
    Dim sKey As Long
    Dim vKey As Long
    Dim Key_Down_Flag As Boolean
    Dim Key_Action As String

    If nCode >= 0 Then
    
        CopyMemory keyMsg, lParam, LenB(keyMsg)
        
        ' get key down/up flag
        If wParam = WM_KEYDOWN Or wParam = WM_SYSKEYDOWN Then
            Key_Down_Flag = True
        Else
            Key_Down_Flag = False
        End If
        
        ' get key scan code for key name
        sKey = keyMsg.sKey And &HFF
        sKey = sKey * 65536
        
        ' get key name
        strLen = GetKeyNameText(sKey, strKeyName, 250)
        strKeyName = Left$(strKeyName, strLen)
        
        ' PageUp, PageDown,Insert, Home, ... share number pad, must define as extend keyboard
        If Left$(strKeyName, 3) = "Num" Then
            sKey = sKey + &H1000000
            
            strLen = GetKeyNameText(sKey, strKeyName, 250)
            strKeyName = Left$(strKeyName, strLen)
        
        End If
        
        ' get ANSI key code
        vKey = keyMsg.vKey
        
        ' [P] for parameter input start, [T] for test
        If vKey = KEY_P Or vKey = KEY_T Then
            
            Input_Key(0) = vKey
            Current_Bit = 1
            
            Mask_Input_Display = True
        
        End If
                
        ' in parameter input stage
        If Mask_Input_Display = True Then
        
            ' only handle key down for parameter input
            If Key_Down_Flag = True Then
            
                ' [F4] is end flag of parameter input
                If vKey = KEY_F4 Then
                
                    ' set end flag
                    Input_Key(Current_Bit) = 0
                        
                    ' handle input
                    If Input_Key(0) = KEY_P Then
                        Handle_Input
                    End If
                
                Else        ' data byte of the parameter input
                
                    ' keep in the buffer
                    Input_Key(Current_Bit) = vKey
                            
                    ' turn to next bit
                    If Current_Bit < 79 Then
                        Current_Bit = Current_Bit + 1
                    End If
                    
                End If
                        
            Else        ' key up
            
                If vKey = KEY_F4 Then
                    
                    ' clear mask flag
                    Mask_Input_Display = False
                    
                End If
                
            End If
        
        Else    ' normal key input
        
            ' set Shift pressed flag
            If vKey = KEY_L_SHIFT Then
            
                If Key_Down_Flag = True Then
                    Shift_Press_Flag = True
                Else
                    Shift_Press_Flag = False
                End If
                
            End If
        
            ' set Alt pressed flag
            If vKey = KEY_L_ALT Then
            
                If Key_Down_Flag = True Then
                    Alt_Press_Flag = True
                Else
                    Alt_Press_Flag = False
                End If
                
            End If
        
            ' display key action and time
            Key_Action = Left(strKeyName, 10)
            
            If Key_Down_Flag = True Then
                Key_Action = "按: "
            Else
                Key_Action = "放: "
            End If
            
            Key_Action = Key_Action + Left(Format(strKeyName, "&&&&&&&&&&"), 10)
            Key_Action = Key_Action + ":" + Format(Now, "HH:MM:SS:MS")
            
            frmMain.lstInput.AddItem Key_Action
            frmMain.lstInput.ListIndex = frmMain.lstInput.ListCount - 1
                
            ' for key up, insert a blank line, except [Ctrl], [Alt], [Shift]
            If Key_Down_Flag = False And vKey <> 160 And vKey <> 162 And vKey <> 164 Then
                frmMain.lstInput.AddItem " "
                frmMain.lstInput.ListIndex = frmMain.lstInput.ListCount - 1
            End If
        
            ' display with button figure
            If Key_Down_Flag = True Then
                
                ' new key down always clear all 6 button backcolor
                For i = 0 To 5
                    frmMain.lblKeys(i).BackColor = &H8000000F
                Next
            
                ' match 6 key defines
                For i = 0 To 5
                    
                    If vKey = Key_On_Define(i) Then
                    
                        frmMain.lblKeys(i).BackColor = &HFF&            ' red
                        frmMain.lblKeys(i).Caption = RTrim$(strKeyName)
                    
                    End If
                Next
            
                ' ESC for stop F5, share same button
                If vKey = KEY_ESC Then
                    frmMain.lblKeys(4).Caption = "ESC"
                End If
            
                ' Shift + F5
                If vKey = KEY_F5 And Shift_Press_Flag = True And Key_Down_Flag = True Then
                    frmMain.lblKeys(4).Caption = "Shift F5"
                End If
                
                ' Alt + Tab
                If vKey = KEY_TAB And Alt_Press_Flag = True And Key_Down_Flag = True Then
                    frmMain.lblKeys(2).Caption = "Alt Tab"
                End If
            
            End If
        
        End If
    
    End If
    
    CallKeyHookProc = 1
    
End Function


Public Function Handle_Input()

    Dim Ratio As Integer

    ' [P]: Paramter
    If Input_Key(0) = 80 Then
    
        ' TX model
        frmMain.lblTxID.Caption = "[" + Chr$(Input_Key(1))
        
        If Input_Key(2) <> 48 Then      ' if receiv "071", just display "71"
            frmMain.lblTxID.Caption = frmMain.lblTxID.Caption + Chr$(Input_Key(2))
        End If
        
        frmMain.lblTxID.Caption = frmMain.lblTxID.Caption + Chr$(Input_Key(3))
        frmMain.lblTxID.Caption = frmMain.lblTxID.Caption + Chr$(Input_Key(4)) + "] - "
        
        ' RX model
        frmMain.lblRxID.Caption = "[" + Chr$(Input_Key(5))
        
        If Input_Key(6) <> 48 Then      ' if receiv "071", just display "71"
            frmMain.lblRxID.Caption = frmMain.lblRxID.Caption + Chr$(Input_Key(6))
        End If
        
        frmMain.lblRxID.Caption = frmMain.lblRxID.Caption + Chr$(Input_Key(7))
        frmMain.lblRxID.Caption = frmMain.lblRxID.Caption + Chr$(Input_Key(8)) + "] - "
        
        ' TX firmware version
        frmMain.lblTxID.Caption = frmMain.lblTxID.Caption + "V" + Chr$(Input_Key(9)) + "." + Chr$(Input_Key(10)) ' version
    
        ' RX firmware version
        frmMain.lblRxID.Caption = frmMain.lblRxID.Caption + "V" + Chr$(Input_Key(11)) + "." + Chr$(Input_Key(12)) ' version
    
        ' TX produce date
        frmMain.lblTxID.Caption = frmMain.lblTxID.Caption + "_20" + Chr$(Input_Key(13)) + Chr$(Input_Key(14)) ' year
        frmMain.lblTxID.Caption = frmMain.lblTxID.Caption + "/" + Chr$(Input_Key(15)) + Chr$(Input_Key(16))   ' month
        frmMain.lblTxID.Caption = frmMain.lblTxID.Caption + "/" + Chr$(Input_Key(17)) + Chr$(Input_Key(18)) ' day
    
        ' RX produce date
        frmMain.lblRxID.Caption = frmMain.lblRxID.Caption + "_20" + Chr$(Input_Key(19)) + Chr$(Input_Key(20)) ' year
        frmMain.lblRxID.Caption = frmMain.lblRxID.Caption + "/" + Chr$(Input_Key(21)) + Chr$(Input_Key(22))   ' month
        frmMain.lblRxID.Caption = frmMain.lblRxID.Caption + "/" + Chr$(Input_Key(23)) + Chr$(Input_Key(24)) ' day
    
        frmMain.lblVolt.Caption = Chr$(Input_Key(25)) + "." + Chr$(Input_Key(26))
    
    End If

End Function




