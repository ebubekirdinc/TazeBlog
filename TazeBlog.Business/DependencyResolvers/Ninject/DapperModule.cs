using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Business.Abstract;
using TazeBlog.Business.Concrete;
using TazeBlog.Core.Utilities.Abstract;
using TazeBlog.Core.Utilities.Concrete;
using TazeBlog.DataAccess.Abstract;
using TazeBlog.DataAccess.Concrete.Dapper;

namespace TazeBlog.Business.DependencyResolvers.Ninject
{
    public class DapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleDal>().To<DapArticleDal>().InSingletonScope();
            Bind<IArticleService>().To<ArticleManager>().InSingletonScope();

            Bind<ICategoryDal>().To<DapCategoryDal>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();

            Bind<IUserDal>().To<DapUserDal>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();

            Bind<ICryptoService>().To<AesCrypto>().InSingletonScope();
        }
    }
}
