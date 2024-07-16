using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class PostComment : BaseEntity
    {

        [Required]
        public string Text { get; set; }


        #region Relations

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        #endregion

    }
}
