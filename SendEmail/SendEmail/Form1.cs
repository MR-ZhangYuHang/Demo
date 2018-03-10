using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SendEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Reciver.Text))
                {
                    MessageBox.Show(@"收件人不能为空！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (string.IsNullOrWhiteSpace(rtxt_Content.Text))
                {
                    MessageBox.Show(@"邮件内容不能为空！", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btn_send.Enabled = false;
                var emailAcount = ConfigurationManager.AppSettings["EmailAcount"];
                var emailPassword = ConfigurationManager.AppSettings["EmailPassword"];
                var reciver = txt_Reciver.Text;
                var content = rtxt_Content.Text;
                MailMessage message = new MailMessage();
                //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
                MailAddress fromAddr = new MailAddress(string.Format("{0}@qq.com", emailAcount));
                message.From = fromAddr;
                //设置收件人,可添加多个,添加方法与下面的一样
                message.To.Add(reciver);
                //设置抄送人
                message.CC.Add("izhaofu@163.com");
                //设置邮件标题
                message.Subject = "Test";
                //设置邮件内容
                message.Body = content;
                //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
                SmtpClient client = new SmtpClient("smtp.qq.com", 25);
                //设置发送人的邮箱账号和密码
                client.Credentials = new NetworkCredential(emailAcount, emailPassword);
                //启用ssl,也就是安全发送
                client.EnableSsl = true;
                //发送邮件
                client.Send(message);
                MessageBox.Show(@"邮件发送成功!", @"提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"异常错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                btn_send.Enabled = true;
            }
        }
    }
}
