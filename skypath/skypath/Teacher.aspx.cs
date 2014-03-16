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

            Bind_Appointments(false);

        }

        void ButtonDelete_Click(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridViewAppointments.Rows[GridViewAppointments.SelectedIndex];

            int appointmentId = (int)GridViewAppointments.DataKeys[selectedRow.RowIndex]["id"];

            DaTeacher daTeacher = new DaTeacher();
            daTeacher.DeleteAppointment(appointmentId);

            Bind_Appointments(true);
        }

        void Bind_Appointments(bool refreshGrid)
        {
            DaTeacher daTeacher = new DaTeacher();

            string userName = User.Identity.Name;

            int? idTeacher = daTeacher.GetTeacherIdByUserName(userName);

            DataTable dtAppointments = daTeacher.GetTeacherAppointments((int)idTeacher);

            GridViewAppointments.DataSource = dtAppointments;

            if (!IsPostBack || refreshGrid)
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

            int? idTeacher = daTeacher.GetTeacherIdByUserName(userName);

            //db call to insert appointment
            daTeacher.InsertNewAppointment(newAppointment, (int)idTeacher);

            Bind_Appointments(true);            

        }

        protected void GridViewAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
        }

    }
}