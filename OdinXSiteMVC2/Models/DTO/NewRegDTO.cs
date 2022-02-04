using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OdinXSiteMVC2.Models.Roles;

namespace OdinXSiteMVC2.Models.DTO {
    public class NewRegDTO {

        //Personal DB for non-secure items.

        [Key]
        //Change ID to make DB more secure. -AT A LATER DATE#GOB
        public string Id { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "UserName")]
        public string userName { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Profile Pic")]
        public string profilePic { get; set; }
        [Display(Name = "Gamer Tag")]
        public string gamerTag { get; set; }
        [Display(Name = "Member Type")]
        public string role { get; set; }
        [ForeignKey("Roles")]
        public string roleId { get; set; }
        
        public Role Roles { get; set; }



        //public string bio { get; set; }


    }
}
