using System.ComponentModel.DataAnnotations;

namespace OdinXSiteMVC2.Models.DTO {
    public class NewRegDTO {

        //Personal DB for non-secure items.

        [Key]
        //Change ID to make DB more secure. -AT A LATER DATE#GOB
        public string Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string userName { get; set; }
        public string email { get; set; }

        public string profilePic { get; set; }
        //public string bio { get; set; }


    }
}
