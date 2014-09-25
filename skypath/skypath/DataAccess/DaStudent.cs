using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using skypath.Utilities;

namespace skypath.DataAccess
{
    public class DaStudent
    {
        public DaStudent()
        {
        }

        public DataTable GetStudentAppointments(int idStudent)
        {
            DataTable results = new DataTable();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@idStudent", idStudent));

            string sqlText = @"                                                                  

                            select [sukotto1_skypath2008].[dbo].[Appointment].id,
                                   [sukotto1_skypath2008].[dbo].[Appointment].appointmentStart,
                                   [sukotto1_skypath2008].[dbo].[Appointment].appointmentEnd,
                                   [sukotto1_skypath2008].[dbo].[User].userName
                            from [sukotto1_skypath2008].[dbo].[Student] 
                            inner join  [sukotto1_skypath2008].[dbo].[Appointment] on
                                        [sukotto1_skypath2008].[dbo].[Appointment].id_Student = 
                                        [sukotto1_skypath2008].[dbo].[Student].id 
                            inner join  [sukotto1_skypath2008].[dbo].[User] on
                                        [sukotto1_skypath2008].[dbo].[Student].id_User = 
                                        [sukotto1_skypath2008].[dbo].[User].id
                            where [sukotto1_skypath2008].[dbo].[Student].id = @idStudent
                            order by [sukotto1_skypath2008].[dbo].[Appointment].appointmentStart
                                
                                ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            results = sqlHelper.SQL_Select(sqlCommand);

            return results;
        }

        public DataTable GetAllOpenAppointments()
        {
            DataTable results = new DataTable();

            SqlCommand sqlCommand = new SqlCommand();

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
                            where [sukotto1_skypath2008].[dbo].[Appointment].id_Student is null
                            order by [sukotto1_skypath2008].[dbo].[Appointment].appointmentStart
                                
                                ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            results = sqlHelper.SQL_Select(sqlCommand);

            return results;
        }

        public int? GetStudentIdByUserName(string userName)
        {
            int? result = -1;

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@userName", userName));

            var resultParameter = sqlCommand.Parameters.Add("@idTeacher", 0);
            resultParameter.Direction = ParameterDirection.Output;

            string sqlText = @"                                                                  

                            select @idTeacher = [sukotto1_skypath2008].[dbo].[Student].id
                            
                            from [sukotto1_skypath2008].[dbo].[Student] 
                            
                            inner join  [sukotto1_skypath2008].[dbo].[User] on
                                [sukotto1_skypath2008].[dbo].[User].id = 
                                [sukotto1_skypath2008].[dbo].[Student].id_User 

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

        public void CancelAppointment(int appointmentId)
        {
            DataTable results = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(new SqlParameter("@idAppointment", appointmentId));

            string sqlText = @"                                                                  

                            update [sukotto1_skypath2008].[dbo].[Appointment]
                            set id_Student = null                    
                            where [sukotto1_skypath2008].[dbo].[Appointment].id = @idAppointment                           
                                
                                ";

            sqlCommand.CommandText = sqlText;
            SQLHelper sqlHelper = new SQLHelper();
            sqlHelper.SQL_Select(sqlCommand);            
        }

        public void BookAppointment(int appointmentId, int studentId)
        {
            DataTable results = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.Add(new SqlParameter("@idAppointment", appointmentId));
            sqlCommand.Parameters.Add(new SqlParameter("@idStudent", studentId));

            string sqlText = @"                                                                  

                            update [sukotto1_skypath2008].[dbo].[Appointment]
                            set id_Student = @idStudent                    
                            where [sukotto1_skypath2008].[dbo].[Appointment].id = @idAppointment                           
                                
                                ";

            sqlCommand.CommandText = sqlText;
            SQLHelper sqlHelper = new SQLHelper();
            sqlHelper.SQL_Select(sqlCommand);     
        }
    }


}