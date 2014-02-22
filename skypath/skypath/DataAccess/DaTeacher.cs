using System;
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

        public DataTable InsertNewAppointment(DateTime newAppointment, int idTeacher)
        {
            DataTable dtResults = new DataTable();

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@appointment", newAppointment));
            sqlCommand.Parameters.Add(new SqlParameter("@idTeacher", idTeacher));

            string sqlText = @"Insert into [sukotto1_skypath2008].[sukotto1_jason2008].[Appointment] 
                                (appointment, id_Teacher)
                                values(@appointment, @idTeacher)                               
                                ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            sqlHelper.SQL_Insert(sqlCommand);

            return dtResults;
        }

        public int GetTeacherIdByUserName(string userName)
        {
            int result = 0;

            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@userName", userName));

            var resultParameter = sqlCommand.Parameters.Add("@idTeacher", 0);
            resultParameter.Direction = ParameterDirection.Output;

            string sqlText = @"                                                                  

                            select @idTeacher = [sukotto1_skypath2008].[sukotto1_jason2008].[Teacher].id
                            from [sukotto1_skypath2008].[sukotto1_jason2008].[Teacher] 
                            inner join  [sukotto1_skypath2008].[sukotto1_jason2008].[User] on
                            [sukotto1_skypath2008].[sukotto1_jason2008].[User].id = 
                            [sukotto1_skypath2008].[sukotto1_jason2008].[Teacher].id_User 
                            where [sukotto1_skypath2008].[sukotto1_jason2008].[User].userName = @userName
                                
                                ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            sqlHelper.SQL_Select(sqlCommand);

            result = int.Parse(resultParameter.Value.ToString());

            return result;
        }
    }
}