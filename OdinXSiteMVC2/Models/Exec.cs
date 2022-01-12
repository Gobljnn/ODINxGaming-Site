using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdinXSiteMVC2.Models {
    public class Exec {
        [Display(Name = "ID")]
        public int execID { get; set; }
        [Display(Name = "First Name")]
        public string execFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string execLastName { get; set; }
        [Display(Name = "Gaming Tag")]
        public string execGamingTag { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Favourite Game")]
        public string? favGame { get; set; }
        [Display(Name = "Title/Position")]
        public string execTitle { get; set; }
        [Display(Name = "Hierarchy Type")]
        public string execHierarchy { get; set; }
        [Display(Name = "login")]
        public int? loginAmt { get; set; }
        //[DataType(DataType.DateTime)]
        //public DateTime lastLogin { get; set; }

        public string execPic { get; set; }
    }
}
