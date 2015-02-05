using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.WebUI.Services
{
    public interface ITagService
    {
        List<string> ParseTags(string line);

        List<tblTags> FindOrAddTags(List<string> tagList);

        tblTags FindOrAddTag(string tag);

        void AttachTagToArticle(List<tblTags> tags, tblArticles article);

    }
}
