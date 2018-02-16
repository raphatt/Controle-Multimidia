Option Strict On
Imports System.Runtime.InteropServices
Public Class Form1
    Dim playpause As Integer = 0
    Dim muteunmute As Integer = 0

    Private Const WM_APPCOMMAND As Integer = &H319
    Private Const APPCOMMAND_VOLUME_MUTE As Integer = &H80000
    Private Const APPCOMMAND_MEDIA_PLAY_PAUSE As Integer = &HE0000
    Private Const APPCOMMAND_MEDIA_NEXTTRACK As Integer = &HB0000
    Private Const APPCOMMAND_MEDIA_PREVIOUSTRACK As Integer = &HC0000

    <DllImport("user32.dll")> Public Shared Function SendMessageW(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
bloco1:
        If playpause = 0 Then
            PictureBox2.Image = Controle_Multimidia.My.Resources.pause
            playpause = 1
            GoTo bloco3
        End If
bloco2:
        If playpause = 1 Then
            PictureBox2.Image = Controle_Multimidia.My.Resources.play
            playpause = 0
            GoTo bloco3
        End If
bloco3:
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_MEDIA_PLAY_PAUSE))
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
bloco1:
        If muteunmute = 0 Then
            PictureBox4.Image = Controle_Multimidia.My.Resources.unmute
            muteunmute = 1
            GoTo bloco3
        End If
bloco2:
        If muteunmute = 1 Then
            PictureBox4.Image = Controle_Multimidia.My.Resources.mute
            muteunmute = 0
            GoTo bloco3
        End If
bloco3:
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_MUTE))
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_MEDIA_PREVIOUSTRACK))
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_MEDIA_NEXTTRACK))
    End Sub

    Private Sub FecharToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharToolStripMenuItem.Click
        Close()
    End Sub
End Class
