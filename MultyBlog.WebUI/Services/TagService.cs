using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Services
{
    public class TagService : ITagService
    {
        private readonly ITagsManager _tagManager;

        public TagService()
        {
            _tagManager = DependencyResolver.Current.GetService<ITagsManager>();
        }

        public List<string> ParseTags(string line)
        {
            Regex rgx = new Regex(@"\S+", RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(line);
            return matches.Cast<Match>().Select(n => n.Value).ToList();
        }


        public List<tblTags> FindOrAddTags(List<string> tagList)
        {
            List<tblTags> dbTagList = new List<tblTags>();

            foreach(string s in tagList)
            {
                dbTagList.Add(this.FindOrAddTag(s));
            }

            return dbTagList;
        }

        public tblTags FindOrAddTag(string tag)
        {



            tblTags dbTag = _tagManager.AddIfNotExist(tag);

            return dbTag;
        }


        public void AttachTagToArticle(List<tblTags> tags, tblArticles article)
        {
            _tagManager.AttachTagToArticle(tags, article);
        }
    }
}