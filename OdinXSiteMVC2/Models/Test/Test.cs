using Microsoft.AspNetCore.Identity;

namespace OdinXSiteMVC2.Models.Test {
    public class Test : IdentityUser {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string bio { get; set; }
        public string execBio { get; set; }
        public string profilePic { get; set; }
        public string execPic { get; set; }

        public string gamerTag { get; set; }
    }
}
