using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using skypath.Utilities;
using System.Data;

namespace skypath.DataAccess
{
    public class DaLogin
    {
        public DaLogin()
        {
        }

        /// <summary>
        /// check login for a user/password, single result is authenticated
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>
        /// returns datatable populated form user data in db
        /// </returns>
        public DataTable Login(string userName, string password)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@userName", userName));
            sqlCommand.Parameters.Add(new SqlParameter("@password", password));

            string sqlText = @"SELECT [id]
                          FROM [sukotto1_skypath2008].[dbo].[User] 
                        where [sukotto1_skypath2008].[dbo].[User].userName = @userName 
                        and [sukotto1_skypath2008].[dbo].[User].password = @password";

            sqlCommand.CommandText = sqlText;


            SQLHelper sqlHelper = new SQLHelper();

            DataTable dtResults = sqlHelper.SQL_Select(sqlCommand);

            return dtResults;
        }

        public string CreateUser(string userName, string password, bool isStudent, string firstName, string lastName)
        {
            string encryptedPassword = Encrypt.EncryptString(password);

            string insert = "";

            if (isStudent)
            {
                insert = @" INSERT INTO [sukotto1_skypath2008].[dbo].[Student] ([id_User])
                               VALUES(SCOPE_IDENTITY())   ";
            }
            else
            {
                insert = @" INSERT INTO [sukotto1_skypath2008].[dbo].[Teacher] ([id_User])
                               VALUES(SCOPE_IDENTITY()) ";
            }


            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@userName", userName));
            sqlCommand.Parameters.Add(new SqlParameter("@password", encryptedPassword));
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", firstName));
            sqlCommand.Parameters.Add(new SqlParameter("@lastName", lastName));

            string sqlText = @"insert into [sukotto1_skypath2008].[dbo].[User] (userName, password, firstName, lastName)
                               values(@userName, @password, @firstName, @lastName)
                               
                                           
                               
                " + insert;

            sqlCommand.CommandText = sqlText;


            SQLHelper sqlHelper = new SQLHelper();

            sqlHelper.SQL_Select(sqlCommand);
            // make error trapping on
            string results = "";
            return results;
        }
    }
}