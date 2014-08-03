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
using System.IO;

namespace skypath
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            this.ButtonAddNewAppointment.Click += new EventHandler(ButtonAddNewAppointment_Click);
            this.ButtonDelete.Click += new EventHandler(ButtonDelete_Click);
            this.ButtonUpload.Click += new EventHandler(ButtonUpload_Click);
            this.DayPilotCalendar1.EventClick += new DayPilot.Web.Ui.Events.EventClickEventHandler(DayPilotCalendar1_EventClick);
=======
                this.ButtonAddNewAppointment.Click += new EventHandler(ButtonAddNewAppointment_Click);
                this.ButtonDelete.Click += new EventHandler(ButtonDelete_Click);
                this.ButtonUpload.Click += new EventHandler(ButtonUpload_Click);
>>>>>>> origin/master

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
                BindTeachers();
        }

        void DayPilotCalendar1_EventClick(object sender, DayPilot.Web.Ui.Events.EventClickEventArgs e)
        {
            string value = e.Value;
            int x = 0;            

        }

        void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                int imageFileLen = FileUpload.PostedFile.ContentLength;
                byte[] imageArray = new byte[imageFileLen];
                HttpPostedFile image = FileUpload.PostedFile;
                image.InputStream.Read(imageArray, 0, imageFileLen);
                //MemoryStream stream = new MemoryStream(imageArray);

                Int32 userId = 2;

                DaImage daImage = new DaImage();
                daImage.SaveImage(userId, imageArray);

            }
        }

        void ButtonDelete_Click(object sender, EventArgs e)
        {
            GridViewRow selectedRow = GridViewAppointments.Rows[GridViewAppointments.SelectedIndex];

            int appointmentId = (int)GridViewAppointments.DataKeys[selectedRow.RowIndex]["id"];

            DaTeacher daTeacher = new DaTeacher();
            daTeacher.DeleteAppointment(appointmentId);

            Bind_Appointments(true);
        }

        private void BindTeachers()
        {
            Image image = new Image();
            image.ImageUrl = "~/ImageHandler.ashx?userId=" + 2;

            PlaceHolderTeachers.Controls.Add(image);
        }

        void Bind_Appointments(bool refreshGrid)
        {
            DaTeacher daTeacher = new DaTeacher();

            string userName = User.Identity.Name;

            int? idTeacher = daTeacher.GetTeacherIdByUserName(userName);

            DataTable dtAppointments = daTeacher.GetTeacherAppointments((int)idTeacher);

            GridViewAppointments.DataSource = dtAppointments;
            DayPilotCalendar1.DataSource = dtAppointments;

            DayPilotCalendar1.DataStartField = "appointmentStart";
            DayPilotCalendar1.DataEndField = "appointmentEnd";
            DayPilotCalendar1.DataTextField = "userName";
            DayPilotCalendar1.DataValueField = "id";
            DayPilotCalendar1.Days = 7;

            if (!IsPostBack || refreshGrid)
            {
                GridViewAppointments.DataBind();
                DayPilotCalendar1.DataBind();
            }            
        }

        void ButtonAddNewAppointment_Click(object sender, EventArgs e)
        {
            int lessonTime = 30;
            DaTeacher daTeacher = new DaTeacher();
            DateTime newAppointmentStart = new DateTime();
            DateTime newAppointmentEnd = new DateTime();
            newAppointmentStart = DateTime.Parse(this.TextBoxDate.Text);
            

            TimeSpan time = TimeSpan.Parse(this.DropDownListTime.SelectedValue);
            
            newAppointmentStart = newAppointmentStart.Add(time);
            newAppointmentEnd = newAppointmentStart.AddMinutes(lessonTime);

            string userName = User.Identity.Name;

            int? idTeacher = daTeacher.GetTeacherIdByUserName(userName);

            //db call to insert appointment
            daTeacher.InsertNewAppointment(newAppointmentStart, newAppointmentEnd, (int)idTeacher);

            Bind_Appointments(true);            

        }

        protected void GridViewAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
        }

    }
}