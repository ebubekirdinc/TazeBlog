using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.DataAccess.Concrete.Dapper;
using TazeBlog.DataAccess.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.DataAccess.Concrete.Dapper
{
    public class DapUserDal : DapEntityRepositoryBase<User, DapperContext>, IUserDal
    {
        public DapUserDal() : base("Users",
            "Username,Email,Password,SaltCode",
            "@Username,@Email,@Password,@SaltCode")
        {

        }
    }
}
