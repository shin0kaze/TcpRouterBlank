namespace TcpRouter.FakeMeter
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      textBoxSerialNumber = new TextBox();
      label1 = new Label();
      label2 = new Label();
      textBoxIpAndPort = new TextBox();
      buttonConnect = new Button();
      statusStrip1 = new StatusStrip();
      toolStripStatusLabel1 = new ToolStripStatusLabel();
      buttonDisconnect = new Button();
      textBox1 = new TextBox();
      statusStrip1.SuspendLayout();
      SuspendLayout();
      // 
      // textBoxSerialNumber
      // 
      textBoxSerialNumber.Location = new Point(130, 10);
      textBoxSerialNumber.Name = "textBoxSerialNumber";
      textBoxSerialNumber.Size = new Size(138, 23);
      textBoxSerialNumber.TabIndex = 0;
      textBoxSerialNumber.Text = "12345678901234";
      textBoxSerialNumber.TextChanged += textBoxSerialNumber_TextChanged;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(20, 13);
      label1.Name = "label1";
      label1.Size = new Size(104, 15);
      label1.TabIndex = 1;
      label1.Text = "Серийный номер";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(20, 42);
      label2.Name = "label2";
      label2.Size = new Size(108, 15);
      label2.TabIndex = 2;
      label2.Text = "IP-адрес:TCP-порт";
      // 
      // textBoxIpAndPort
      // 
      textBoxIpAndPort.Location = new Point(130, 39);
      textBoxIpAndPort.Name = "textBoxIpAndPort";
      textBoxIpAndPort.Size = new Size(138, 23);
      textBoxIpAndPort.TabIndex = 3;
      textBoxIpAndPort.Text = "127.0.0.1:12345";
      textBoxIpAndPort.TextChanged += textBoxIpAndPort_TextChanged;
      // 
      // buttonConnect
      // 
      buttonConnect.Location = new Point(130, 84);
      buttonConnect.Name = "buttonConnect";
      buttonConnect.Size = new Size(138, 29);
      buttonConnect.TabIndex = 4;
      buttonConnect.Text = "Подключиться";
      buttonConnect.UseVisualStyleBackColor = true;
      buttonConnect.Click += buttonConnect_Click;
      // 
      // statusStrip1
      // 
      statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
      statusStrip1.Location = new Point(0, 262);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Size = new Size(763, 22);
      statusStrip1.TabIndex = 5;
      statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      toolStripStatusLabel1.Size = new Size(748, 17);
      toolStripStatusLabel1.Spring = true;
      toolStripStatusLabel1.Text = "toolStripStatusLabel1";
      toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // buttonDisconnect
      // 
      buttonDisconnect.Location = new Point(130, 119);
      buttonDisconnect.Name = "buttonDisconnect";
      buttonDisconnect.Size = new Size(138, 29);
      buttonDisconnect.TabIndex = 6;
      buttonDisconnect.Text = "Отключиться";
      buttonDisconnect.UseVisualStyleBackColor = true;
      buttonDisconnect.Visible = false;
      buttonDisconnect.Click += buttonDisconnect_Click;
      // 
      // textBox1
      // 
      textBox1.BackColor = SystemColors.WindowText;
      textBox1.ForeColor = Color.YellowGreen;
      textBox1.Location = new Point(274, 1);
      textBox1.Multiline = true;
      textBox1.Name = "textBox1";
      textBox1.ReadOnly = true;
      textBox1.ScrollBars = ScrollBars.Vertical;
      textBox1.Size = new Size(489, 258);
      textBox1.TabIndex = 7;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(763, 284);
      Controls.Add(textBox1);
      Controls.Add(buttonDisconnect);
      Controls.Add(statusStrip1);
      Controls.Add(buttonConnect);
      Controls.Add(textBoxIpAndPort);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(textBoxSerialNumber);
      Name = "Form1";
      Text = "Form1";
      statusStrip1.ResumeLayout(false);
      statusStrip1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox textBoxSerialNumber;
    private Label label1;
    private Label label2;
    private TextBox textBoxIpAndPort;
    private Button buttonConnect;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private Button buttonDisconnect;
    private TextBox textBox1;
  }
}