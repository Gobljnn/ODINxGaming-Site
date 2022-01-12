using System.ComponentModel.DataAnnotations;

namespace OdinXSiteMVC2.Models.DTO {
    public class NewRegDTO {

        [Key]
        public string id { get; set; }

        public string name { get; set; }

        public string userName { get; set; }
    }
}
