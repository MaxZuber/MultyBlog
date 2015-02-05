using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultyBlog.WebUI.Models
{
    public class NewArticleModel
    {
            public string Content { set; get; }
            public string Header { set; get; }
            public DateTime Date { set; get; }

            public string Username { set; get; }
            public string Tags { set; get; }
    }
}