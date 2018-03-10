#SendEmail

发送邮件服务
```
            var emailAcount = ConfigurationManager.AppSettings["EmailAcount"];
            var emailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            var reciver = txt_Reciver.Text;
            var content = rtxt_Content.Text;
            MailMessage message = new MailMessage();
            //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
            MailAddress fromAddr = new MailAddress("qwe12456@qq.com");
            message.From = fromAddr;
            //设置收件人,可添加多个,添加方法与下面的一样
            message.To.Add(reciver);
            //设置抄送人
            message.CC.Add("qwe1233456@163.com");
            //设置邮件标题
            message.Subject = "Test";
            //设置邮件内容
            message.Body = content;
            //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
            SmtpClient client = new SmtpClient("smtp.qq.com", 25);
            //设置发送人的邮箱账号和密码
            client.Credentials = new NetworkCredential(emailAcount,emailPassword);
            //启用ssl,也就是安全发送
            client.EnableSsl = true;
            //发送邮件
            client.Send(message);
```



###另外推广一下作者的另一款图床工具：MPic图床神器（[mpic.lzhaofu.cn](http://mpic.lzhaofu.cn)）,支持多种上传方式：

###截图上传、拖曳上传、复制上传、选择上传

###有这方面需求的朋友可以去体验一下。

###附：下面是即将推出上线全新改版的UI界面：

![输入图片说明](https://git.oschina.net/uploads/images/2017/0709/112239_2423ba48_461512.png "在这里输入图片标题")

![输入图片说明](https://git.oschina.net/uploads/images/2017/0709/112257_a5226e7b_461512.png "在这里输入图片标题")

![输入图片说明](https://git.oschina.net/uploads/images/2017/0709/112309_02fa23ea_461512.png "在这里输入图片标题")

![输入图片说明](https://git.oschina.net/uploads/images/2017/0709/112318_d362ba4d_461512.png "在这里输入图片标题")