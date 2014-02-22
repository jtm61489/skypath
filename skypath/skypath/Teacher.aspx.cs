﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skypath.Utilities;
using System.Data.SqlClient;
using skypath.DataAccess;

namespace skypath
{
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ButtonAddNewAppointment.Click += new EventHandler(ButtonAddNewAppointment_Click);

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
        }

        void ButtonAddNewAppointment_Click(object sender, EventArgs e)
        {
            DaTeacher daTeacher = new DaTeacher();
            DateTime newAppointment = new DateTime();

            newAppointment = DateTime.Parse(this.TextBoxDate.Text);

            TimeSpan time = TimeSpan.Parse(this.DropDownListTime.SelectedValue);

            newAppointment.Add(time);

            string userName = User.Identity.Name;

            int idTeacher = daTeacher.GetTeacherIdByUserName(userName);            

            //db call to insert appointment
            daTeacher.InsertNewAppointment(newAppointment, idTeacher);

        }
    }
}