using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities
{
    public class Category : BaseEntity
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        [AllowNull]
        public string MetaTag { get; set; }

        [AllowNull]
        public string MetaDescription { get; set; }

        public int? ParentId { get; set; }


        #region Relations

        [AllowNull]
        public ICollection<Post> Posts { get; set; }

        #endregion
    }
}
