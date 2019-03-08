using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.DataAccess.Concrete.Dapper;
using TazeBlog.DataAccess.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.DataAccess.Concrete.Dapper
{
    public class DapCategoryDal : DapEntityRepositoryBase<Category, DapperContext>, ICategoryDal
    {
        public DapCategoryDal() : base(
            "Categories",
            "Name,Description,Permalink,CreatedOn,Status",
            "@Name,@Description,@Permalink,@CreatedOn,@Status")
        {

        }
    }
}
