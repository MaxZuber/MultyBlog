using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using MultyBlog.Dal.Abstract;
using MultyBlog.Dal.Concrete;
using System.Configuration;

namespace MultyBlog.WebUI
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["MultyBlogDbEntityWeb"].ConnectionString;


        container.RegisterType<IArticleManager, ArticleManager>(new InjectionConstructor(connectionString));
        container.RegisterType<IUserManager, UserManager>(new InjectionConstructor(connectionString));
        container.RegisterType<ICommentsManager, CommentsManager>(new InjectionConstructor(connectionString));
        container.RegisterType<ITagsManager, TagsManager>(new InjectionConstructor(connectionString));

    }
  }
}