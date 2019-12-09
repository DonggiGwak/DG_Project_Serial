namespace Serial_SharpThreadExample
{
    partial class ucSerialPort
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_comport = new System.Windows.Forms.Label();
            this.com_portnum = new System.Windows.Forms.ComboBox();
            this.com_baudrate = new System.Windows.Forms.ComboBox();
            this.lbl_baudrate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_comport
            // 
            this.lbl_comport.AutoSize = true;
            this.lbl_comport.Location = new System.Drawing.Point(5, 7);
            this.lbl_comport.Name = "lbl_comport";
            this.lbl_comport.Size = new System.Drawing.Size(72, 12);
            this.lbl_comport.TabIndex = 1;
            this.lbl_comport.Text = "PortNumber";
            // 
            // com_portnum
            // 
            this.com_portnum.FormattingEnabled = true;
            this.com_portnum.Location = new System.Drawing.Point(83, 4);
            this.com_portnum.Name = "com_portnum";
            this.com_portnum.Size = new System.Drawing.Size(80, 20);
            this.com_portnum.TabIndex = 1;
            // 
            // com_baudrate
            // 
            this.com_baudrate.FormattingEnabled = true;
            this.com_baudrate.Location = new System.Drawing.Point(83, 30);
            this.com_baudrate.Name = "com_baudrate";
            this.com_baudrate.Size = new System.Drawing.Size(80, 20);
            this.com_baudrate.TabIndex = 2;
            // 
            // lbl_baudrate
            // 
            this.lbl_baudrate.AutoSize = true;
            this.lbl_baudrate.Location = new System.Drawing.Point(22, 33);
            this.lbl_baudrate.Name = "lbl_baudrate";
            this.lbl_baudrate.Size = new System.Drawing.Size(55, 12);
            this.lbl_baudrate.TabIndex = 3;
            this.lbl_baudrate.Text = "Baudrate";
            // 
            // ucSerialPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.com_baudrate);
            this.Controls.Add(this.lbl_baudrate);
            this.Controls.Add(this.lbl_comport);
            this.Controls.Add(this.com_portnum);
            this.Name = "ucSerialPort";
            this.Size = new System.Drawing.Size(169, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox com_baudrate;
        private System.Windows.Forms.Label lbl_baudrate;
        private System.Windows.Forms.ComboBox com_portnum;
        private System.Windows.Forms.Label lbl_comport;
    }
}
