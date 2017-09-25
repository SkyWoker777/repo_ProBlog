using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBlog.Core.Etities
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public virtual IList<Post> Articles { get; set; }
    }
}
