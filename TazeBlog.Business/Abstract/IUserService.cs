using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.Business.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.Business.Abstract
{
    public interface IUserService : IService<User>
    {
        bool PasswordCheck(User user, string Password);
    }
}
