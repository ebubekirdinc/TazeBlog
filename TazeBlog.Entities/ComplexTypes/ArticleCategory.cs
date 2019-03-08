using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Entities.Concrete;

namespace TazeBlog.Entities.ComplexTypes
{
    public class ArticleCategory : Article
    {
        public List<Category> Categories { get; set; }
    }
}
