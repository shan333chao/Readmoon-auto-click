namespace LazyPressClick
{
    partial class AutoHotKey
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.CB_IsPressAlt = new System.Windows.Forms.CheckBox();
            this.cbSpeed = new System.Windows.Forms.ComboBox();
            this.lbllook = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CB_IsPressAlt
            // 
            this.CB_IsPressAlt.AutoSize = true;
            this.CB_IsPressAlt.Checked = true;
            this.CB_IsPressAlt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_IsPressAlt.Location = new System.Drawing.Point(38, 36);
            this.CB_IsPressAlt.Name = "CB_IsPressAlt";
            this.CB_IsPressAlt.Size = new System.Drawing.Size(66, 16);
            this.CB_IsPressAlt.TabIndex = 1;
            this.CB_IsPressAlt.Text = "按住Alt";
            this.CB_IsPressAlt.UseVisualStyleBackColor = true;
            // 
            // cbSpeed
            // 
            this.cbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeed.FormattingEnabled = true;
            this.cbSpeed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbSpeed.Items.AddRange(new object[] {
            "0.3",
            "0.5",
            "0.8",
            "0.9",
            "1",
            "1.5",
            "2"});
            this.cbSpeed.Location = new System.Drawing.Point(179, 10);
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.Size = new System.Drawing.Size(49, 20);
            this.cbSpeed.TabIndex = 2;
            // 
            // lbllook
            // 
            this.lbllook.AutoSize = true;
            this.lbllook.ForeColor = System.Drawing.Color.Red;
            this.lbllook.Location = new System.Drawing.Point(36, 55);
            this.lbllook.Name = "lbllook";
            this.lbllook.Size = new System.Drawing.Size(299, 72);
            this.lbllook.TabIndex = 10;
            this.lbllook.Text = "使用快捷键说明：\r\n开始   Ctrl+Home\r\n停止   Alt + End\r\n注意：\r\n1、如果未勾选了按住Alt，停止只需按Alt + End组合键\r\n2" +
    "、请使用快捷键开关\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "多少毫秒点一次鼠标左键";
            // 
            // BT_Start
            // 
            this.BT_Start.Location = new System.Drawing.Point(252, 10);
            this.BT_Start.Name = "BT_Start";
            this.BT_Start.Size = new System.Drawing.Size(75, 23);
            this.BT_Start.TabIndex = 16;
            this.BT_Start.Text = "开始";
            this.BT_Start.UseVisualStyleBackColor = true;
            this.BT_Start.Click += new System.EventHandler(this.BT_Start_Click);
            // 
            // AutoHotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 138);
            this.Controls.Add(this.BT_Start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbllook);
            this.Controls.Add(this.cbSpeed);
            this.Controls.Add(this.CB_IsPressAlt);
            this.Name = "AutoHotKey";
            this.Text = "跟我一只手来撸";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoHotKey_FormClosing);
            this.Load += new System.EventHandler(this.AutoHotKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CB_IsPressAlt;
        private System.Windows.Forms.ComboBox cbSpeed;
        private System.Windows.Forms.Label lbllook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_Start;
    }
}

