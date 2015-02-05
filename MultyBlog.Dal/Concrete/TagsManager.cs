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
    public class TagsManager : AbstractManager, IManager, ITagsManager
    {

        public TagsManager(string connectionString) : base(connectionString) { }

        public List<string> GetArticleTags(int ID)
        {
            List<string> tags;

            using (DbContext context = this.CreateDbContext())
            {
                tags = context.Set<tblArticlesTags>()
                    .Include(n => n.tblArticles)
                    .Include(n => n.tblTags)
                    .Where(n => n.tblArticles.ID == ID)
                    .Select(n => n.tblTags.Name)
                    .ToList();
            }

            return tags;
        }


        public List<tblArticles> GetAllArticlesWithTag(string tag)
        {
            List<tblArticles> articles;

            using (DbContext context = this.CreateDbContext())
            {
                articles = context.Set<tblArticlesTags>()
                    .Where(n => n.tblTags.Name == tag)
                    .Select(n => n.tblArticles)
                    .Include(n => n.tblUsers)
                    .ToList();

                context.Set<tblTags>().Single(n => n.Name == tag).TagRequest += 1;
                context.SaveChanges();
            }

            return articles;
        }


        public List<tblTags> GetPopularTagsTop(int count)
        {
            List<tblTags> popularTags;

            using(DbContext context = this.CreateDbContext())
            {
                popularTags = context.Set<tblTags>().OrderByDescending(n => n.TagRequest).Take(count).ToList();
            }

            return popularTags;
        }


        public tblTags AddIfNotExist(string tag)
        {
            tblTags newTag;

            using(DbContext context = this.CreateDbContext())
            {
                newTag = context.Set<tblTags>().SingleOrDefault(n => n.Name == tag);

                if(newTag == null)
                {

                    newTag = new tblTags()
                    {
                        Name = tag,
                        TagRequest = 0   
                    };
                    context.Set<tblTags>().Add(newTag);

                    context.SaveChanges();
                }
            }
            return newTag;
        }


        public void AttachTagToArticle(List<tblTags> tags, tblArticles article)
        {
            using (DbContext context = this.CreateDbContext())
            {

                //List<tblArticlesTags> articleTags = new List<tblArticlesTags>();

                foreach(tblTags t in tags)
                {
                    context.Set<tblArticlesTags>().Add(new tblArticlesTags ( ) {
                        ArticleID = article.ID,
                        TagID = t.ID
                    });
                }
                context.SaveChanges();
                
            }
        }
    }
}
