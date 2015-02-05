using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultyBlog.WebUI.Models
{
    public class ArticleCommentModel
    {
        public int ArticleID { set; get; }
        public string Text { set; get; }
        public string UserName { set; get; }
        public DateTime Date { set; get; }
    }
}