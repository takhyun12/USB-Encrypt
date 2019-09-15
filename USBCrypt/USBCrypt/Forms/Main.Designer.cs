namespace USBCrypt
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Decrypt_Btn = new System.Windows.Forms.Button();
            this.Encrypt_Btn = new System.Windows.Forms.Button();
            this.status_lb = new System.Windows.Forms.Label();
            this.logo_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // Decrypt_Btn
            // 
            this.Decrypt_Btn.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Decrypt_Btn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Decrypt_Btn.Location = new System.Drawing.Point(401, 255);
            this.Decrypt_Btn.Name = "Decrypt_Btn";
            this.Decrypt_Btn.Size = new System.Drawing.Size(190, 38);
            this.Decrypt_Btn.TabIndex = 6;
            this.Decrypt_Btn.Text = "파일 작업모드";
            this.Decrypt_Btn.UseVisualStyleBackColor = true;
            this.Decrypt_Btn.Click += new System.EventHandler(this.Decrypt_Btn_Click);
            // 
            // Encrypt_Btn
            // 
            this.Encrypt_Btn.Enabled = false;
            this.Encrypt_Btn.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Encrypt_Btn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Encrypt_Btn.Location = new System.Drawing.Point(12, 255);
            this.Encrypt_Btn.Name = "Encrypt_Btn";
            this.Encrypt_Btn.Size = new System.Drawing.Size(190, 38);
            this.Encrypt_Btn.TabIndex = 5;
            this.Encrypt_Btn.Text = "파일 보관모드";
            this.Encrypt_Btn.UseVisualStyleBackColor = true;
            this.Encrypt_Btn.Click += new System.EventHandler(this.Encrypt_Btn_Click);
            // 
            // status_lb
            // 
            this.status_lb.AutoSize = true;
            this.status_lb.BackColor = System.Drawing.Color.Transparent;
            this.status_lb.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.status_lb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.status_lb.Location = new System.Drawing.Point(226, 43);
            this.status_lb.Name = "status_lb";
            this.status_lb.Size = new System.Drawing.Size(137, 19);
            this.status_lb.TabIndex = 7;
            this.status_lb.Text = "파일 암호화 동작중";
            // 
            // logo_icon
            // 
            this.logo_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("logo_icon.Icon")));
            this.logo_icon.Text = "USB 통합 보안 프로그램";
            this.logo_icon.Visible = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::USBCrypt.Properties.Resources.encrypted;
            this.ClientSize = new System.Drawing.Size(603, 305);
            this.Controls.Add(this.status_lb);
            this.Controls.Add(this.Decrypt_Btn);
            this.Controls.Add(this.Encrypt_Btn);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "USB 통합 보안 프로그램";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Decrypt_Btn;
        private System.Windows.Forms.Button Encrypt_Btn;
        private System.Windows.Forms.Label status_lb;
        private System.Windows.Forms.NotifyIcon logo_icon;
    }
}

