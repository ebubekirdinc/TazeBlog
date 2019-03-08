using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.Entities;

namespace TazeBlog.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SaltCode { get; set; }
    }
}
