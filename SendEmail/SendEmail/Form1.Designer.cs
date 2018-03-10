namespace SendEmail
{
    partial class Form1
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
            this.btn_send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Reciver = new System.Windows.Forms.TextBox();
            this.rtxt_Content = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(148, 206);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(144, 44);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "发送邮件";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "收件人";
            // 
            // txt_Reciver
            // 
            this.txt_Reciver.Location = new System.Drawing.Point(104, 28);
            this.txt_Reciver.Name = "txt_Reciver";
            this.txt_Reciver.Size = new System.Drawing.Size(295, 21);
            this.txt_Reciver.TabIndex = 2;
            // 
            // rtxt_Content
            // 
            this.rtxt_Content.Location = new System.Drawing.Point(104, 85);
            this.rtxt_Content.Name = "rtxt_Content";
            this.rtxt_Content.Size = new System.Drawing.Size(295, 94);
            this.rtxt_Content.TabIndex = 3;
            this.rtxt_Content.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "邮件内容";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 262);
            this.Controls.Add(this.rtxt_Content);
            this.Controls.Add(this.txt_Reciver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_send);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Reciver;
        private System.Windows.Forms.RichTextBox rtxt_Content;
        private System.Windows.Forms.Label label2;
    }
}

