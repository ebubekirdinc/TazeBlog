using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.Entities;

namespace TazeBlog.Entities.Concrete
{
    public class Article : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Permalink { get; set; }

    }
}
