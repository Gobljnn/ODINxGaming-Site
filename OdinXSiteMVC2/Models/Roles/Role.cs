using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdinXSiteMVC2.Models.Roles {
    public class Role {
        [Key]
        public string  roleID { get; set; }
        //public string rawRoleID { get; set; }

        public string roleName { get; set; }

    }
}
