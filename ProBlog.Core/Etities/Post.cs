using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProBlog.Core.Etities
{
    public class Post : Entity
    {
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public string Preview { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }

        [Required(ErrorMessage = "Please specify a category.")]
        public Category Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual IList<Tag> Tags { get; set; }
    }
}
