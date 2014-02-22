using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using skypath.Utilities;
using skypath.DataAccess;

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
            string password = this.LoginUser.Password;

            DaLogin daLogin = new DaLogin();
            DataTable dtResults = daLogin.Login(userName, password);

            if (dtResults.Rows.Count == 1)
            {
                //login verified
                FormsAuthentication.RedirectFromLoginPage(userName, true);
            }

             /******javascript will take care of alert of bad password/username*******/
        }

    }
}
