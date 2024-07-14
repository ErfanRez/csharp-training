using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        [AllowNull]
        public string MetaTag { get; set; }

        [AllowNull]
        public string MetaDescription { get; set; }

        [AllowNull]
        public ICollection<Post> Posts { get; set; }
    }
}
