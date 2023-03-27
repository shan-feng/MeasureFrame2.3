<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tabControl_main = New System.Windows.Forms.TabControl()
        Me.tabPage_autorun = New System.Windows.Forms.TabPage()
        Me.HWindow_HE1 = New ChoiceTech.Halcon.Control.HWindow_HE()
        Me.btnSoftTrigger = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tabPage_measure = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.HWindow_HE2 = New ChoiceTech.Halcon.Control.HWindow_HE()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtbox_showLog = New System.Windows.Forms.RichTextBox()
        Me.tabControl_main.SuspendLayout()
        Me.tabPage_autorun.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl_main
        '
        Me.tabControl_main.Controls.Add(Me.tabPage_autorun)
        Me.tabControl_main.Controls.Add(Me.tabPage_measure)
        Me.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl_main.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tabControl_main.HotTrack = True
        Me.tabControl_main.ItemSize = New System.Drawing.Size(100, 38)
        Me.tabControl_main.Location = New System.Drawing.Point(0, 0)
        Me.tabControl_main.Name = "tabControl_main"
        Me.tabControl_main.SelectedIndex = 0
        Me.tabControl_main.Size = New System.Drawing.Size(1050, 622)
        Me.tabControl_main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabControl_main.TabIndex = 784
        '
        'tabPage_autorun
        '
        Me.tabPage_autorun.Controls.Add(Me.TableLayoutPanel1)
        Me.tabPage_autorun.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tabPage_autorun.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tabPage_autorun.Location = New System.Drawing.Point(4, 42)
        Me.tabPage_autorun.Margin = New System.Windows.Forms.Padding(0)
        Me.tabPage_autorun.Name = "tabPage_autorun"
        Me.tabPage_autorun.Size = New System.Drawing.Size(1042, 576)
        Me.tabPage_autorun.TabIndex = 0
        Me.tabPage_autorun.Text = "自动运行"
        Me.tabPage_autorun.UseVisualStyleBackColor = True
        '
        'HWindow_HE1
        '
        Me.HWindow_HE1.BackColor = System.Drawing.Color.Transparent
        Me.HWindow_HE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HWindow_HE1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HWindow_HE1.DrawModel = False
        Me.HWindow_HE1.Image = Nothing
        Me.HWindow_HE1.Location = New System.Drawing.Point(3, 3)
        Me.HWindow_HE1.Name = "HWindow_HE1"
        Me.HWindow_HE1.Size = New System.Drawing.Size(515, 375)
        Me.HWindow_HE1.TabIndex = 4
        '
        'btnSoftTrigger
        '
        Me.btnSoftTrigger.Location = New System.Drawing.Point(111, 59)
        Me.btnSoftTrigger.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSoftTrigger.Name = "btnSoftTrigger"
        Me.btnSoftTrigger.Size = New System.Drawing.Size(56, 35)
        Me.btnSoftTrigger.TabIndex = 3
        Me.btnSoftTrigger.Text = "软件触发"
        Me.btnSoftTrigger.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(171, 59)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(2)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(56, 35)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "停止运行"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(41, 59)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(2)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(56, 35)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "开始运行"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tabPage_measure
        '
        Me.tabPage_measure.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tabPage_measure.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tabPage_measure.Location = New System.Drawing.Point(4, 42)
        Me.tabPage_measure.Margin = New System.Windows.Forms.Padding(0)
        Me.tabPage_measure.Name = "tabPage_measure"
        Me.tabPage_measure.Size = New System.Drawing.Size(1042, 576)
        Me.tabPage_measure.TabIndex = 10
        Me.tabPage_measure.Text = "视觉编辑"
        Me.tabPage_measure.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtbox_showLog, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.HWindow_HE2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.HWindow_HE1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.14584!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.85417!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1042, 576)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'HWindow_HE2
        '
        Me.HWindow_HE2.BackColor = System.Drawing.Color.Transparent
        Me.HWindow_HE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HWindow_HE2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HWindow_HE2.DrawModel = False
        Me.HWindow_HE2.Image = Nothing
        Me.HWindow_HE2.Location = New System.Drawing.Point(524, 3)
        Me.HWindow_HE2.Name = "HWindow_HE2"
        Me.HWindow_HE2.Size = New System.Drawing.Size(515, 375)
        Me.HWindow_HE2.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnStart)
        Me.Panel1.Controls.Add(Me.btnStop)
        Me.Panel1.Controls.Add(Me.btnSoftTrigger)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 384)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(515, 189)
        Me.Panel1.TabIndex = 6
        '
        'txtbox_showLog
        '
        Me.txtbox_showLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtbox_showLog.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.txtbox_showLog.Location = New System.Drawing.Point(524, 384)
        Me.txtbox_showLog.Name = "txtbox_showLog"
        Me.txtbox_showLog.ReadOnly = True
        Me.txtbox_showLog.Size = New System.Drawing.Size(515, 189)
        Me.txtbox_showLog.TabIndex = 809
        Me.txtbox_showLog.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 622)
        Me.Controls.Add(Me.tabControl_main)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "FormVBDemo"
        Me.tabControl_main.ResumeLayout(False)
        Me.tabPage_autorun.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabControl_main As TabControl
    Friend WithEvents tabPage_autorun As TabPage
    Friend WithEvents btnSoftTrigger As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents tabPage_measure As TabPage
    Friend WithEvents HWindow_HE1 As ChoiceTech.Halcon.Control.HWindow_HE
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents HWindow_HE2 As ChoiceTech.Halcon.Control.HWindow_HE
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtbox_showLog As RichTextBox
End Class
