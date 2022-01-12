using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdinXSiteMVC2.Models {
    public class UserImage {
        [Key]
        public int Id { get; set; }
        public string userName { get; set; }
        [ForeignKey("Users")]
        public int userID { get; set; }
        public Exec Users { get; set; }
        //[ForeignKey("ImageID")]
        public string imageName { get; set; }
        public string imagePath { get; set; }
    }
}
