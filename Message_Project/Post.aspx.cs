using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


namespace Message_Project
{
    public partial class Post : System.Web.UI.Page
    {
        DataClasses1DataContext database = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }

        protected void dsShowPosts_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Result = (from a in database.tbl_Posts
                        orderby a.PostId descending
                        where a.State == true
                        select new
                        {
                            a.Title,
                            a.Like,
                            a.DisLike,
                            a.Picture,
                            a.Publisher,
                            a.Date,
                            a.Content,
                            a.PostId
                        }).ToList();
        }
       //-----------------------------------

        public static string RemoveHTMLTags(string content)
        {
            var cleaned = string.Empty;
            try
            {
                StringBuilder textOnly = new StringBuilder();
                using (var reader = XmlNodeReader.Create(new System.IO.StringReader("<xml>" + content + "</xml>")))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Text)
                            textOnly.Append(reader.ReadContentAsString());
                    }
                }
                cleaned = textOnly.ToString();
            }
            catch
            {
                //A tag is probably not closed. fallback to regex string clean.
                string textOnly = string.Empty;
                Regex tagRemove = new Regex(@"<[^>]*(>|$)");
                Regex compressSpaces = new Regex(@"[\s\r\n]+");
                textOnly = tagRemove.Replace(content, string.Empty);
                textOnly = compressSpaces.Replace(textOnly, " ");
                cleaned = textOnly;
            }

            return cleaned;
        }

        protected void lstViewShowPost_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
          
            if (e.CommandName=="AddLike")
            {
                int postid = int.Parse(e.CommandArgument.ToString());
                tbl_Post t = database.tbl_Posts.First(c => c.PostId == postid);
                t.Like += 1;
                database.SubmitChanges();
                lstViewShowPost.DataBind(); 
            }
            else if (e.CommandName=="DisLike")
            {
                int postid = int.Parse(e.CommandArgument.ToString());
                tbl_Post t = database.tbl_Posts.First(c => c.PostId == postid);
                t.DisLike -= 1;
                database.SubmitChanges();
                lstViewShowPost.DataBind(); 
            }
        }

   
    }
}