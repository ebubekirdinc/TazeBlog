using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using TazeBlog.Core.DataAccess.Concrete.Dapper;
using TazeBlog.DataAccess.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.DataAccess.Concrete.Dapper
{
    public class DapArticleDal : DapEntityRepositoryBase<Article, DapperContext>, IArticleDal
    {
        public DapArticleDal() : base(
            tableName: "Articles",
            colums: "Name,Content,Permalink,CategoryId,Status,CreatedOn",
            parameters: "@Name,@Content,@Permalink,@CategoryId,@Status,@CreatedOn")
        {

        }

        

    }
}
