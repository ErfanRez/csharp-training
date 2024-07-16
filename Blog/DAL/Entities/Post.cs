using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities
{
    // [Table("posts", Schema = "dbo")]
    public class Post : BaseEntity
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [AllowNull]
        public int Visit { get; set; }

        [Required]
        public string Slug { get; set; }

        
        #region Relations

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [AllowNull]
        public ICollection<PostComment> PostComments { get; set; }

        #endregion

    }

}
