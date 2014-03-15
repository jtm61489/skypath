using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skypath.Utilities;
using System.Data.SqlClient;
using skypath.DataAccess;
using System.Data;

namespace skypath
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ButtonAddNewAppointment.Click += new EventHandler(ButtonAddNewAppointment_Click);
            this.ButtonDelete.Click += new EventHandler(ButtonDelete_Click);
            GridViewAppointments.DataBound += new EventHandler(GridViewAppointments_DataBound);
            

            // make times for drop down list
            for (int i = 0; i <= 23; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    string hourAndMinute = Convert.ToString(i);
                    if (j == 0)
                    {
                        hourAndMinute += ":00";

                    }
                    else
                    {
                        hourAndMinute += ":30";
                    }

                    this.DropDownListTime.Items.Add(new ListItem(hourAndMinute, hourAndMinute));
                }
            }

            Bind_Appointments();

        }

        void GridViewAppointments_DataBound(object sender, EventArgs e)
        {
            //GridViewAppointments.Columns[GridViewHelper.GetColumnID("id", GridViewAppointments)].Visible = false;
        }

        void ButtonDelete_Click(object sender, EventArgs e)
        {
           // GridViewAppointments.Columns[GridViewHelper.GetColumnID("id", GridViewAppointments)].Visible = true;

            //int columnID = GridViewHelper.GetColumnID("id", GridViewAppointments);

            GridViewRow selectedRow = GridViewAppointments.Rows[GridViewAppointments.SelectedIndex];

            int appointmentId = (int)GridViewAppointments.DataKeys[selectedRow.RowIndex]["id"];
                //GridViewHelper.GetGridViewInt(selectedRow, columnID);

            DaTeacher daTeacher = new DaTeacher();
   //         daTeacher.DeleteAppointment(appointmentId);

            Bind_Appointments();
        }

        void Bind_Appointments()
        {
            DaTeacher daTeacher = new DaTeacher();

            string userName = User.Identity.Name;

            int idTeacher = daTeacher.GetTeacherIdByUserName(userName);

            DataTable dtAppointments = daTeacher.GetTeacherAppointments(idTeacher);

            GridViewAppointments.DataSource = dtAppointments;

            if (!IsPostBack)
            {
                GridViewAppointments.DataBind();
            }            
        }

        void ButtonAddNewAppointment_Click(object sender, EventArgs e)
        {
            DaTeacher daTeacher = new DaTeacher();
            DateTime newAppointment = new DateTime();

            newAppointment = DateTime.Parse(this.TextBoxDate.Text);

            TimeSpan time = TimeSpan.Parse(this.DropDownListTime.SelectedValue);

            newAppointment = newAppointment.Add(time);

            string userName = User.Identity.Name;

            int idTeacher = daTeacher.GetTeacherIdByUserName(userName);

            //db call to insert appointment
            daTeacher.InsertNewAppointment(newAppointment, idTeacher);

            Bind_Appointments();

        }

        protected void GridViewAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
        }

    }
}