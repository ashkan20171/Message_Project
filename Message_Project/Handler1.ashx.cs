using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Message_Project
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string uname = context.Request.QueryString["login"];
            context.Response.ContentType = "Image/Jpeg";
            Stream strm = ShowImgByUname(uname);
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);
            while(byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public Stream ShowImgByUname(string uname)
        {
            DataClasses1DataContext contex = new DataClasses1DataContext();
            var Query=(from a in contex.tbl_users where a.Username==uname select a).First();
            return new MemoryStream(Query.Picture.ToArray());

        }
    }
}