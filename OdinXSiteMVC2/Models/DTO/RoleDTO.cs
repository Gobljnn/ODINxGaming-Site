using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OdinXSiteMVC2.Models.DTO
{
    public class RoleDTO : IdentityRole 
    {
        public string roleID { get; set; }

        public string roleName { get; set; }

        //public IEnumerable<SelectListItem> Select { set; get; }
    }
}
