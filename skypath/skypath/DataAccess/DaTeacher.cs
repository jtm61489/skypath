﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using skypath.Utilities;

namespace skypath.DataAccess
{
    public class DaTeacher
    {
        public DaTeacher()
        {
        }

        public DataTable InsertNewAppointment(DateTime newAppointmentStart, DateTime newAppointmentEnd, int idTeacher)
        {
            DataTable dtResults = new DataTable();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@appointmentStart", newAppointmentStart));
            sqlCommand.Parameters.Add(new SqlParameter("@appointmentEnd", newAppointmentEnd));
            sqlCommand.Parameters.Add(new SqlParameter("@idTeacher", idTeacher));

            string sqlText = @"Insert into [sukotto1_skypath2008].[dbo].[Appointment] 
                                (appointmentStart, appointmentEnd, id_Teacher)
                                values(@appointmentStart, @appointmentEnd, @idTeacher)                               
                                ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            sqlHelper.SQL_Insert(sqlCommand);

            return dtResults;
        }

        public int? GetTeacherIdByUserName(string userName)
        {
            int? result = -1;

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@userName", userName));

            var resultParameter = sqlCommand.Parameters.Add("@idTeacher", 0);
            resultParameter.Direction = ParameterDirection.Output;

            string sqlText = @"                                                                  

                            select @idTeacher = [sukotto1_skypath2008].[dbo].[Teacher].id
                            
                            from [sukotto1_skypath2008].[dbo].[Teacher] 
                            
                            inner join  [sukotto1_skypath2008].[dbo].[User] on
                                [sukotto1_skypath2008].[dbo].[User].id = 
                                [sukotto1_skypath2008].[dbo].[Teacher].id_User 

                            where [sukotto1_skypath2008].[dbo].[User].userName = @userName                            
    
                                ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            sqlHelper.SQL_Select(sqlCommand);

            if (!String.IsNullOrEmpty(resultParameter.Value.ToString()))
            {
                result = int.Parse(resultParameter.Value.ToString());
            }      

            return result;
        }

        public DataTable GetTeacherAppointments(int idTeacher)
        {
            DataTable results = new DataTable();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@idTeacher", idTeacher));

            string sqlText = @"                                                                  

                            select [sukotto1_skypath2008].[dbo].[Appointment].id,
                                   [sukotto1_skypath2008].[dbo].[Appointment].appointmentStart,
                                   [sukotto1_skypath2008].[dbo].[Appointment].appointmentEnd,
                                   [sukotto1_skypath2008].[dbo].[User].userName
                            from [sukotto1_skypath2008].[dbo].[Teacher] 
                            inner join  [sukotto1_skypath2008].[dbo].[Appointment] on
                                        [sukotto1_skypath2008].[dbo].[Appointment].id_Teacher = 
                                        [sukotto1_skypath2008].[dbo].[Teacher].id 
                            inner join  [sukotto1_skypath2008].[dbo].[User] on
                                        [sukotto1_skypath2008].[dbo].[Teacher].id_User = 
                                        [sukotto1_skypath2008].[dbo].[User].id
                            where [sukotto1_skypath2008].[dbo].[Teacher].id = @idTeacher
                            order by [sukotto1_skypath2008].[dbo].[Appointment].appointmentStart
                                
                                ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            results = sqlHelper.SQL_Select(sqlCommand);

            return results;
        }

        public DataTable DeleteAppointment(int idAppointment)
        {
            DataTable results = new DataTable();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@idAppointment", idAppointment));

            string sqlText = @"
              
                            Delete from [sukotto1_skypath2008].[dbo].[Appointment]
                            where [sukotto1_skypath2008].[dbo].[Appointment].id = @idAppointment
                                
                                ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            results = sqlHelper.SQL_Select(sqlCommand);

            return results;
        }
    }
}