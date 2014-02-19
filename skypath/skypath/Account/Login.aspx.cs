using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace skypath.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            this.LoginUser.LoggingIn += new LoginCancelEventHandler(LoginUser_LoggingIn);
        }

        void LoginUser_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            string userName = this.LoginUser.UserName;
            string passoword = this.LoginUser.Password;

            //check database


            //login verified
            FormsAuthentication.RedirectFromLoginPage(userName, true); 
        }

    }
}
