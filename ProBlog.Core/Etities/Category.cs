using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBlog.Core.Etities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        [NotMapped]
        public int PostsCount { get; set; }
    }
}
