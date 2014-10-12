using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using skypath.DataAccess;
using System.Data;

namespace skypath.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
            bool isStudent = true;

            string firstName = (RegisterUser.FindControl("CreateUserStepContainer").FindControl("TextBoxFirstName") as TextBox).Text; 
            string lastName = (RegisterUser.FindControl("CreateUserStepContainer").FindControl("TextBoxLastName") as TextBox).Text;
            
            // TO MAKE THIS DATA DRIVEN
            string studentOrTeacher = (RegisterUser.FindControl("CreateUserStepContainer").FindControl("DropDownListTeacherStudent") as DropDownList).SelectedItem.ToString();

            if (studentOrTeacher == "Teacher")
            {
                isStudent = false;
            }



            DaLogin daLogin = new DaLogin();
            string error = daLogin.CreateUser(RegisterUser.UserName, RegisterUser.Password, isStudent, firstName, lastName);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

    }
}
