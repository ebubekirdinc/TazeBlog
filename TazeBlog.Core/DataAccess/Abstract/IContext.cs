using System;
using System.Collections.Generic;
using System.Text;

namespace TazeBlog.Core.DataAccess.Abstract
{
    public interface IContext
    {
        string ConnectionString { get; set; }
    }
}
