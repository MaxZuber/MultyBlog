using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultyBlog.WebUI.Models
{
    public class ArticleContentModel
    {
        public string Content { set; get; }
        public string Header { set; get; }
        public DateTime Date { set; get; }

        public string Username { set; get; }
        public List<string> Tags { set; get; }
    }
}