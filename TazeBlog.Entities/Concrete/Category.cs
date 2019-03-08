using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.Entities;

namespace TazeBlog.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Permalink { get; set; }

    }
}
