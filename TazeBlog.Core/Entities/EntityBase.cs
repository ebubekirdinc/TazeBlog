using System;
using System.Collections.Generic;
using System.Text;
using TazeBlog.Core.Entities.Enums;

namespace TazeBlog.Core.Entities
{
    public class EntityBase
    {
        public DateTime CreatedOn { get; set; }
        public RowStatus Status { get; set; }
    }
}
