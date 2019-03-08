using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Business.Abstract;
using TazeBlog.Core.Business.Concrete;
using TazeBlog.Core.Utilities.Abstract;
using TazeBlog.DataAccess.Abstract;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.Business.Concrete
{
    public class UserManager : ServiceBase<User>, IUserService
    {
        private ICryptoService _cryptoService;
        public UserManager(IUserDal userDal, ICryptoService cryptoService) : base(userDal)
        {
            _cryptoService = cryptoService;
        }

        public bool PasswordCheck(User user, string password)
        {
            return _cryptoService.Decrypt(user.Password, user.SaltCode) == password;
        }
    }
}
