using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.Dal.Abstract
{
    public interface ICommentsManager
    {
        List<tblComments> GetByArticleId(int id);
        List<tblComments> AddCommentToArticleById(int ArticleID, tblComments comment);

    }
}
