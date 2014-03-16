using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skypath.DataAccess;
using System.Data;

namespace skypath
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ButtonBookAppointment.Click += new EventHandler(ButtonBookAppointment_Click);
            this.ButtonCancel.Click += new EventHandler(ButtonCancel_Click);

            Bind_All_Appointments(false);
            Bind_Student_Appointments(false);
        }

        void ButtonCancel_Click(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridViewStudentAppointments.Rows[GridViewStudentAppointments.SelectedIndex];

            int appointmentId = (int)GridViewStudentAppointments.DataKeys[selectedRow.RowIndex]["id"];

            DaStudent daStudent = new DaStudent();

            daStudent.CancelAppointment(appointmentId);

            GridViewStudentAppointments.SelectedIndex = -1;

            Bind_All_Appointments(true);
            Bind_Student_Appointments(true);
        }

        void ButtonBookAppointment_Click(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridViewAllAppointments.Rows[GridViewAllAppointments.SelectedIndex];

            int appointmentId = (int)GridViewAllAppointments.DataKeys[selectedRow.RowIndex]["id"];

            string userName = User.Identity.Name;

            DaStudent daStudent = new DaStudent();

            int? idStudent = daStudent.GetStudentIdByUserName(userName);

            daStudent.BookAppointment(appointmentId, (int)idStudent);

            GridViewAllAppointments.SelectedIndex = -1;

            Bind_All_Appointments(true);
            Bind_Student_Appointments(true);
        }

        public void Bind_All_Appointments(bool refreshGrid)
        {
            DaStudent daStudent = new DaStudent();
            DataTable dtAllAppointments = daStudent.GetAllOpenAppointments();

            GridViewAllAppointments.DataSource = dtAllAppointments;

            if (!IsPostBack || refreshGrid)
            {
                GridViewAllAppointments.DataBind();
            }    
        }

        public void Bind_Student_Appointments(bool refreshGrid)
        {
            DaStudent daStudent = new DaStudent();

            string userName = User.Identity.Name;

            int? idStudent = daStudent.GetStudentIdByUserName(userName);

            DataTable dtStudentAppointments = daStudent.GetStudentAppointments((int)idStudent);

            GridViewStudentAppointments.DataSource = dtStudentAppointments;

            if (!IsPostBack || refreshGrid)
            {
                GridViewStudentAppointments.DataBind();
            }    
        }

    }
}