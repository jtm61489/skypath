using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
//using System.Web.Mail;

namespace skypath
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnSend_Click(object sender, System.EventArgs e)
        {
            MailMessage objMail = new MailMessage("test@skypath.jp", "scottbrussell@gmail.com", "test", "test body");
            NetworkCredential objNC = new NetworkCredential("test@skypath.jp", "Qwer1234");
            SmtpClient objsmtp = new SmtpClient("webmail.skypath.jp", 25); // for hotmail
            //objsmtp.EnableSsl = true;
            objsmtp.Credentials = objNC;
            objsmtp.Send(objMail);
            lblStatus.Text = txtFrom.Text + "has sent email (" + txtSubject.Text + ") to " + txtTo.Text;
        }
    }
}