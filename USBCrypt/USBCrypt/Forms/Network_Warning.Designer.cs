namespace USBCrypt.Forms
{
    partial class Network_Warning
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Network_Warning));
            this.lan_pb = new System.Windows.Forms.PictureBox();
            this.status_lb = new System.Windows.Forms.Label();
            this.deny_lb = new System.Windows.Forms.Label();
            this.main_tm = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lan_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // lan_pb
            // 
            this.lan_pb.Image = global::USBCrypt.Properties.Resources.LAN;
            this.lan_pb.Location = new System.Drawing.Point(10, 3);
            this.lan_pb.Name = "lan_pb";
            this.lan_pb.Size = new System.Drawing.Size(122, 149);
            this.lan_pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.lan_pb.TabIndex = 0;
            this.lan_pb.TabStop = false;
            // 
            // status_lb
            // 
            this.status_lb.AutoSize = true;
            this.status_lb.BackColor = System.Drawing.Color.Transparent;
            this.status_lb.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.status_lb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.status_lb.Location = new System.Drawing.Point(166, 77);
            this.status_lb.Name = "status_lb";
            this.status_lb.Size = new System.Drawing.Size(569, 34);
            this.status_lb.TabIndex = 8;
            this.status_lb.Text = "USB 사용간 랜선을 분리하여 주시기 바랍니다";
            // 
            // deny_lb
            // 
            this.deny_lb.AutoSize = true;
            this.deny_lb.BackColor = System.Drawing.Color.Transparent;
            this.deny_lb.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deny_lb.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.deny_lb.Location = new System.Drawing.Point(187, 48);
            this.deny_lb.Name = "deny_lb";
            this.deny_lb.Size = new System.Drawing.Size(503, 21);
            this.deny_lb.TabIndex = 9;
            this.deny_lb.Text = "안전한 업무수행을 위해 네트워크를 자동으로 차단하였습니다";
            // 
            // main_tm
            // 
            this.main_tm.Enabled = true;
            this.main_tm.Tick += new System.EventHandler(this.main_tm_Tick);
            // 
            // Network_Warning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(776, 156);
            this.Controls.Add(this.deny_lb);
            this.Controls.Add(this.status_lb);
            this.Controls.Add(this.lan_pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Network_Warning";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USBCrypt";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Network_Warning_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.lan_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox lan_pb;
        private System.Windows.Forms.Label status_lb;
        private System.Windows.Forms.Label deny_lb;
        private System.Windows.Forms.Timer main_tm;
    }
}