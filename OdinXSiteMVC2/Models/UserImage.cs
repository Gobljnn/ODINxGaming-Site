using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdinXSiteMVC2.Models {

    //This class is used as the bridge between user and profile pictures. It keeps a history of all files uploaded
    public class UserImage {
        [Key]
        public int Id { get; set; }

        //Implement Foreign Keys - AT LATER DATE#GOB

        [ForeignKey("Users")]
        public string userID { get; set; }
        public Exec Users { get; set; }
        //[ForeignKey("ImageID")]
        public string imageName { get; set; }
        public string imagePath { get; set; }
    }
}
