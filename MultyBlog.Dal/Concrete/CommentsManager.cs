using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyBlog.Dal.Concrete
{
    public class CommentsManager : AbstractManager, IManager, ICommentsManager
    {
        public CommentsManager(string connectionString) : base(connectionString) { }

        public List<tblComments> GetByArticleId(int id)
        {
            List<tblComments> comments;

            using (DbContext context = this.CreateDbContext())
            {
                comments = context.Set<tblComments>()
                    .Where(n => n.ArticleID == id)
                    .Include(n => n.tblUsers)
                    .ToList();
            }

            return comments;
        }

        public List<tblComments> AddCommentToArticleById(int ArticleID, tblComments comment)
        {
            List<tblComments> comments;

            using (DbContext context = this.CreateDbContext())
            {

                tblUsers user = context.Set<tblUsers>().Single(n => n.ID == comment.UserID);
                tblArticles article = context.Set<tblArticles>().Single(n => n.ID == ArticleID);

                comment.tblArticles = article;
                comment.tblUsers = user;

                context.Set<tblComments>().Add(comment);
                context.SaveChanges();

                comments = context.Set<tblComments>()

                    .Where(n => n.ArticleID == ArticleID)
                    .Include(n => n.tblUsers)
                    .ToList();
            }

            return comments;
        }
    }
}
