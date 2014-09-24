using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using skypath.Utilities;
using System.Data;

namespace skypath.DataAccess
{
    public class DaImage
    {
        public DaImage()
        {
        }

        /// <summary>
        /// check login for a user/password, single result is authenticated
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataTable GetImage(Int32 userId)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@userId", userId));            

            string sqlText = @"SELECT [picture]
                          FROM [sukotto1_skypath2008].[dbo].[Teacher]
                          where [sukotto1_skypath2008].[dbo].[Teacher].id_User = @userId
                            ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            DataTable dtResults = sqlHelper.SQL_Select(sqlCommand);

            return dtResults;
        }

        /// <summary>
        /// check login for a user/password, single result is authenticated
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void SaveImage(Int32 userId, byte[] image)
        {
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Parameters.Add(new SqlParameter("@userId", userId));
            sqlCommand.Parameters.Add(new SqlParameter("@image", image));

            string sqlText = @"UPDATE [sukotto1_skypath2008].[dbo].[Teacher]
                               SET [picture] = @image 
                               where [sukotto1_skypath2008].[dbo].[Teacher].id_User = @userId
                            ";

            sqlCommand.CommandText = sqlText;

            SQLHelper sqlHelper = new SQLHelper();

            sqlHelper.SQL_Insert(sqlCommand);
        }
    }
}