using OdinXSiteMVC2.Models.Roles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdinXSiteMVC2.Models.DTO
{
    public class AdminEditDTO
    {

        [Key]
        //Change ID to make DB more secure. -AT A LATER DATE#GOB
        public string Id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string userName { get; set; }

        public string gamerTag { get; set; }
        public string bio { get; set; }
        public string execBio { get; set; }
        public string profilePic { get; set; }
        public string execPic { get; set; }
        public List<Role> Roles { get; set; }


    }
}
