using System.ComponentModel.DataAnnotations;

namespace OdinXSiteMVC2.Models.DTO {
    public class NewRegDTO {

        [Key]
        public string Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string userName { get; set; }
        public string email { get; set; }

        public string profilePic { get; set; }
        //public string bio { get; set; }


    }
}
