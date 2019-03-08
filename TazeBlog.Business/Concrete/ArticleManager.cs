using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Business.Abstract;
using TazeBlog.Core.Business.Concrete;
using TazeBlog.DataAccess.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.Business.Concrete
{
    public class ArticleManager : ServiceBase<Article>, IArticleService
    {
        public ArticleManager(IArticleDal articleDal) : base(articleDal)
        {

        }


    }
}
