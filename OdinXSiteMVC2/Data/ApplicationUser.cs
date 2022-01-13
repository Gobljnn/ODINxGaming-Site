﻿using Microsoft.AspNetCore.Identity;

namespace OdinXSiteMVC2.Data {
    public class ApplicationUser : IdentityUser {

        //AUTHORIZATION USER ADDITIONAL INFO
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string bio { get; set; }

    }
}
