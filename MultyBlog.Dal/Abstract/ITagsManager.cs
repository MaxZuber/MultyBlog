using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.Dal.Abstract
{
    public interface ITagsManager
    {

        List<string> GetArticleTags(int ID);

        List<tblArticles> GetAllArticlesWithTag(string tag);

        List<tblTags> GetPopularTagsTop(int count);

        tblTags AddIfNotExist(string tag);

        void AttachTagToArticle(List<tblTags> tags, tblArticles article);
    }
}
