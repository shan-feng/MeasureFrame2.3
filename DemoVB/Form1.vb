Imports ChoiceTech.Halcon.Control
Imports CPublicDefine
Imports Measure
Imports MeasureFrame.IUI

Public Class Form1
    Public gFrmVision As frm_Main


    Public Sub DlgInsertHe(ByVal list As List(Of HImageExt), ByVal projectName As String)
        If projectName.Contains("CCD") Then
            For Each he As HImageExt In list
                HWindow_HE1.showHE(he)
            Next

        End If
        Try
            For Each he As HImageExt In list
                tempHWindow_HE.showHE(he)
            Next
            tempHWindow_HE.SaveWindowDump("d:\test.png")
        Catch ex As Exception

        End Try

    End Sub
    Dim tempHWindow_HE As New HWindow_HE() '该窗口为保存效果图的载体
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Module1.s_Form1 = Me
        '视觉测量程序初始化
        tempHWindow_HE.Size = New Size(2592， 1944)
        CHelper.InsertHe2ExtWindow = New CHelper.InsertHE2AutoRunWindow(AddressOf DlgInsertHe)
        Try
            'Measure.VBA_Function.Show("")
            Measure.HMeasureSYS.InitialVisionProgram(Measure.HMeasureSYS.sConfigPath)

            If HMeasureSYS.CheckDevStatus() = False Then
                MessageBox.Show("存在相机未连接,请检查")
            End If
            InitTcpClient(gTcpClient, "127.0.0.1", 5000)

            ''视觉界面 默认是不加载刷新的,所以需要手动设置才行,将视觉界面嵌入到主程序  magical 20171122 edit by zhangli at 20171125
            If gFrmVision Is Nothing OrElse gFrmVision.IsDisposed Then
                gFrmVision = New frm_Main
                gFrmVision.MdiParent = Me
                gFrmVision.FormBorderStyle = FormBorderStyle.None
                gFrmVision.WindowState = FormWindowState.Normal
                gFrmVision.Parent = Me.tabPage_measure
                gFrmVision.Dock = DockStyle.Fill
                gFrmVision.Show()
                frm_Main.thisHandle = gFrmVision
            Else
                gFrmVision.Activate()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        HMeasureSYS.Sys_StartTest(0)
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        HMeasureSYS.Sys_Stop()
    End Sub

    Private Sub btnSoftTrigger_Click(sender As Object, e As EventArgs) Handles btnSoftTrigger.Click
        Dim 定位相机软触发 As Boolean = True
        If 定位相机软触发 Then
            HMeasureSYS.setTrigger("TR1")
        Else
            'gCard_主卡1.setOut(enumIO_out_主卡1.定位相机触发, enumState.StateOff)
            'gCard_主卡1.setOut(enumIO_out_主卡1.定位相机触发, enumState.StateOn)
            'Threading.Thread.Sleep(200)
            'gCard_主卡1.setOut(enumIO_out_主卡1.定位相机触发, enumState.StateOff)
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ModTCPIP.DisConnectTcp(ModTCPIP.gTcpClient)
            HMeasureSYS.DisposeVisionProgram()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UpdateLogInfo(ByVal input As String)
        If Me.Created Then
            txtbox_showLog.BeginInvoke(
                Sub()
                    If txtbox_showLog.Lines.Length > 1000 Then
                        txtbox_showLog.Clear()
                    End If

                    txtbox_showLog.AppendText($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }:{input} {System.Environment.NewLine}")
                    txtbox_showLog.ScrollToCaret()
                End Sub)
        End If
    End Sub
End Class
