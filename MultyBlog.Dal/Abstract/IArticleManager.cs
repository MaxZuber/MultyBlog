using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MultyBlog.Entities;

namespace MultyBlog.Dal.Abstract
{
    public interface IArticleManager
    {
        List<tblArticles> GetAll();


        tblArticles GetById(int ID);

        void AddNewArticle(tblArticles article);

        List<tblArticles> GetPopularToday();
       
    }
}
