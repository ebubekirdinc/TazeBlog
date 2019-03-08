using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TazeBlog.Core.DataAccess.Abstract;
using TazeBlog.Core.DataAccess.Concrete;
using TazeBlog.Core.Entities;

namespace TazeBlog.DataAccess.Concrete.Dapper
{
    public class DapperContext : IContext
    {
        public string ConnectionString { get; set; }
        public DapperContext()
        {
            ConnectionString = "@SERVER=.;Database=TazeBlog;Trusted_Connection=true;";
        }
    }
}
