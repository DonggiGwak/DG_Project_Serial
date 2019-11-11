namespace Serial_SharpExample
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btn_serialOpen = new System.Windows.Forms.Button();
            this.com_portNum = new System.Windows.Forms.ComboBox();
            this.listBox_serialRcv = new System.Windows.Forms.ListBox();
            this.btn_array_test = new System.Windows.Forms.Button();
            this.btn_sample = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // btn_serialOpen
            // 
            this.btn_serialOpen.Location = new System.Drawing.Point(126, 12);
            this.btn_serialOpen.Name = "btn_serialOpen";
            this.btn_serialOpen.Size = new System.Drawing.Size(85, 20);
            this.btn_serialOpen.TabIndex = 1;
            this.btn_serialOpen.Text = "열기";
            this.btn_serialOpen.UseVisualStyleBackColor = true;
            this.btn_serialOpen.Click += new System.EventHandler(this.btn_serialOpen_Click);
            // 
            // com_portNum
            // 
            this.com_portNum.FormattingEnabled = true;
            this.com_portNum.Location = new System.Drawing.Point(12, 12);
            this.com_portNum.Name = "com_portNum";
            this.com_portNum.Size = new System.Drawing.Size(108, 20);
            this.com_portNum.TabIndex = 2;
            // 
            // listBox_serialRcv
            // 
            this.listBox_serialRcv.FormattingEnabled = true;
            this.listBox_serialRcv.ItemHeight = 12;
            this.listBox_serialRcv.Location = new System.Drawing.Point(233, 12);
            this.listBox_serialRcv.Name = "listBox_serialRcv";
            this.listBox_serialRcv.Size = new System.Drawing.Size(555, 424);
            this.listBox_serialRcv.TabIndex = 3;
            // 
            // btn_array_test
            // 
            this.btn_array_test.Location = new System.Drawing.Point(12, 334);
            this.btn_array_test.Name = "btn_array_test";
            this.btn_array_test.Size = new System.Drawing.Size(199, 102);
            this.btn_array_test.TabIndex = 4;
            this.btn_array_test.Text = "배열테스트";
            this.btn_array_test.UseVisualStyleBackColor = true;
            this.btn_array_test.Click += new System.EventHandler(this.btn_array_test_Click);
            // 
            // btn_sample
            // 
            this.btn_sample.Location = new System.Drawing.Point(12, 48);
            this.btn_sample.Name = "btn_sample";
            this.btn_sample.Size = new System.Drawing.Size(199, 81);
            this.btn_sample.TabIndex = 5;
            this.btn_sample.Text = "샘플 보내기";
            this.btn_sample.UseVisualStyleBackColor = true;
            this.btn_sample.Click += new System.EventHandler(this.btn_sample_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_sample);
            this.Controls.Add(this.btn_array_test);
            this.Controls.Add(this.listBox_serialRcv);
            this.Controls.Add(this.com_portNum);
            this.Controls.Add(this.btn_serialOpen);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btn_serialOpen;
        private System.Windows.Forms.ComboBox com_portNum;
        private System.Windows.Forms.ListBox listBox_serialRcv;
        private System.Windows.Forms.Button btn_array_test;
        private System.Windows.Forms.Button btn_sample;
        private System.Windows.Forms.Timer timer1;
    }
}

