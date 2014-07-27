using System;
using System.Web;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using skypath.DataAccess;

namespace skypath
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Int32 userId;
            if (context.Request.QueryString["userId"] != null)
                userId = Convert.ToInt32(context.Request.QueryString["userId"]);
            else
                throw new ArgumentException("No parameter specified");

            context.Response.ContentType = "image/jpeg";
            Stream strm = getImage(userId);
            byte[] buffer = new byte[2048];
            int byteSeq = strm.Read(buffer, 0, 2048);
            //Test File output. IIS_USR *SHOULD* have write access to this path, but if not you may have to grant it
            FileStream fso = new FileStream(Path.Combine(context.Request.PhysicalApplicationPath, "test.jpg"), FileMode.Create);

            while (byteSeq > 0)
            {
                fso.Write(buffer, 0, byteSeq);
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 2048);
            }

            fso.Close();
        }

        public Stream getImage(Int32 userId)
        {
            object theImg = null;

            DaImage daImage = new DaImage();
            DataTable dtImage = daImage.GetImage(userId);

            theImg = dtImage.Rows[0]["picture"];

            return new MemoryStream((byte[])theImg);
        }        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
