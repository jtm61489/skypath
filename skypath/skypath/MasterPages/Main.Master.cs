using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace skypath.MasterPages
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl ulMainMenu = new HtmlGenericControl("ul");
            ulMainMenu.Attributes.Add("role","navigation");

            HtmlGenericControl liMainMenu1 = new HtmlGenericControl("li");            
            HtmlGenericControl aMainMenu1 = new HtmlGenericControl("a");
            aMainMenu1.Attributes.Add("href", "Default.aspx");
            aMainMenu1.InnerText = "Home";
            liMainMenu1.Controls.Add(aMainMenu1);
            ulMainMenu.Controls.Add(liMainMenu1);

            HtmlGenericControl liMainMenu2 = new HtmlGenericControl("li");
            HtmlGenericControl aMainMenu2 = new HtmlGenericControl("a");
            aMainMenu2.Attributes.Add("href", "Teacher.aspx");
            aMainMenu2.InnerText = "Teacher";
            liMainMenu2.Controls.Add(aMainMenu2);
            ulMainMenu.Controls.Add(liMainMenu2);

            HtmlGenericControl liMainMenu3 = new HtmlGenericControl("li");
            HtmlGenericControl aMainMenu3 = new HtmlGenericControl("a");
            aMainMenu3.Attributes.Add("href", "Student.aspx");
            aMainMenu3.InnerText = "Student";
            liMainMenu3.Controls.Add(aMainMenu3);
            ulMainMenu.Controls.Add(liMainMenu3);

            this.ContentPlaceHolderMainMenu.Controls.Add(ulMainMenu);
        }
    }
}