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

            //check database
            string connString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@userName", userName));
            sqlCommand.Parameters.Add(new SqlParameter("@password", password));

            string sqlText = @"SELECT [id]
                              ,[userName]
                              ,[firstName]
                              ,[lastName]
                              ,[password]
                          FROM [sukotto1_skypath2008].[sukotto1_jason2008].[User] 
                        where [sukotto1_skypath2008].[sukotto1_jason2008].[User].userName = @userName 
                        and [sukotto1_skypath2008].[sukotto1_jason2008].[User].password = @password";

            sqlCommand.CommandText = sqlText;

            DataTable dtResults = new DataTable();

            
            // Open connection
            using (SqlConnection c = new SqlConnection(connString))
            {
                sqlCommand.Connection = c;
                c.Open();
                
                using (SqlDataReader dr = sqlCommand.ExecuteReader())
                {                    
                    dtResults.Load(dr);                
                }
            }            

            if (dtResults.Rows.Count == 1)
            {
                //login verified
                FormsAuthentication.RedirectFromLoginPage(userName, true);
            }

             /******javascript will take care of alert of bad password/username*******/
        }

    }
}
