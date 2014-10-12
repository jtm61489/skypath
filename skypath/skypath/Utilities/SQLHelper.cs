using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace skypath.Utilities
{

    public class SQLHelper
    {
        //connection string
        string CONNECTION = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        public SQLHelper()
        {
        }

        /// <summary>
        /// give command for select statement to db
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public DataTable SQL_Select(SqlCommand sqlCommand)
        {
            DataTable dtResults = new DataTable();

            // Open connection
            using (SqlConnection c = new SqlConnection(CONNECTION))
            {
                sqlCommand.Connection = c;
                c.Open();

                using (SqlDataReader dr = sqlCommand.ExecuteReader())
                {
                    dtResults.Load(dr);
                }
            }

            return dtResults;
        }

        public void SQL_Insert(SqlCommand sqlCommand)
        {
            using (SqlConnection c = new SqlConnection(CONNECTION))
            {
                sqlCommand.Connection = c;
                c.Open();

                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void SQL_Update()
        {
        }

        public void SQL_Delete()
        {
        }
    }
}