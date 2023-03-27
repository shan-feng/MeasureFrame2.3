Imports Helper.Socket

Module ModTCPIP
    Public WithEvents gTcpClient As Helper.Socket.DMTcpClient
    ''' <summary>
    ''' 初始化TcpClient通讯
    ''' </summary>
    ''' <param name="tcpClient">tcpip对象</param>
    ''' <param name="serverIP">服务器IP</param>
    ''' <param name="port">端口号</param>
    ''' <returns>true 连接成功  false 连接失败</returns>
    ''' <remarks></remarks>
    Public Function InitTcpClient(ByRef tcpClient As DMTcpClient, ByVal serverIP As String, ByVal port As Integer) As Boolean
        Try
            If tcpClient Is Nothing Then
                tcpClient = New DMTcpClient
                tcpClient.ServerIp = serverIP
                tcpClient.ServerPort = port
                tcpClient.ReConnectionTime = 2000
            ElseIf tcpClient.Tcpclient.Connected = True Then
                Return True
            End If
            tcpClient.StartConnection()
            Return True
        Catch ex As Exception
            'InfoUpdate("-->tcpip通讯连接失败,Ip: " & serverIP, enumLogLevel.警告信息)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' tcpClient 断开连接
    ''' </summary>
    ''' <param name="tcpClient">客户端通讯</param>
    ''' <remarks></remarks>
    Public Sub DisConnectTcp(ByRef tcpClient As DMTcpClient)
        If Not tcpClient Is Nothing Then
            tcpClient.StopConnection()
            tcpClient.Dispose()
        End If
    End Sub
#Region "CCD通讯"
    ''' <summary>
    ''' CCD通讯错误提示
    ''' </summary>
    ''' <param name="msg">错误信息</param>
    ''' <remarks></remarks>
    Public Sub OnCCDErrorMsg(ByVal msg As String) Handles gTcpClient.OnErrorMsg
        ' InfoUpdate("-->tcpIp 视觉通讯错误：" & msg, enumLogLevel.错误信息)
    End Sub

    ''' <summary>
    ''' CCD通讯状态
    ''' </summary>
    ''' <param name="msg">状态信息</param>
    ''' <param name="state">状态</param>
    ''' <remarks></remarks>
    Public Sub OnCCDStateInfo(ByVal msg As String, ByVal state As SocketState) Handles gTcpClient.OnStateInfo
        Select Case state
            Case SocketState.Connecting
                'InfoUpdate("-->尝试连接视觉：" & msg, enumLogLevel.回滚信息)
            Case SocketState.Connected
                'InfoUpdate("-->成功连接视觉：" & msg, enumLogLevel.回滚信息)
            Case SocketState.Disconnect
                'InfoUpdate("-->断开连接视觉：" & msg, enumLogLevel.回滚信息)
            Case SocketState.Reconnection
                'InfoUpdate("-->尝试重连视觉：" & msg, enumLogLevel.回滚信息)
        End Select
    End Sub

    ''' <summary>
    ''' CCD接受数据回调
    ''' </summary>
    ''' <param name="dataByt">接受数据</param>
    ''' <remarks></remarks>
    Public Sub OnCCDReceviceByte(ByVal dataByt() As Byte) Handles gTcpClient.OnReceviceByte
        Try

            Dim strReceive As String = Helper.DBCTool.ToDBC(System.Text.Encoding.Default.GetString(dataByt))
            Module1.UpdateLogInfo("视觉返回结果: " + strReceive)
        Catch ex As Exception
        Finally
        End Try
    End Sub
#End Region
End Module

