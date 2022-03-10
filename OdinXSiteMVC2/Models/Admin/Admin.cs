using System.ComponentModel.DataAnnotations;

namespace OdinXSiteMVC2.Models.Admin {
    public class Admin {

        [Key]
        //Change ID to make DB more secure. -AT A LATER DATE#GOB
        public string Id { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "GamerTag")]
        public string gamerTag { get; set; }
        [Display(Name = "Profile Bio")]
        public string bio { get; set; }
        [Display(Name = "Exec Bio")]
        public string execBio { get; set; }
        [Display(Name = "Profile Pic")]
        public string profilePic { get; set; }
        [Display(Name = "Exec Pic")]
        public string execPic { get; set; }
        //public List<Role> Roles { get; set; }

    }
}
