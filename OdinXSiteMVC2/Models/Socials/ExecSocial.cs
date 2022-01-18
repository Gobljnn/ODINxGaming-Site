using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdinXSiteMVC2.Models.Socials {
    public class ExecSocial {

        [Key]
        public int socialID { get; set; }
        [ForeignKey("Users")]
        public string execId { get; set; }
        public Exec Users { get; set; }
        
        [Display(Name = "Name")]
        public string execName { get; set; }
        [Display(Name = "Channel")]
        public string discordName { get; set; }
        [Display(Name = "Discord")]
        public string discordLink { get; set; }

        [Display(Name = "Twitch")]
        public string ttvlink { get; set; }

        [Display(Name = "Instagram")]
        public string instaLink { get; set; }

        [Display(Name = "Twitter")]
        public string twitLink { get; set; }

        [Display(Name = "TikTok")]
        public string tiktokLink { get; set; }


        [Display(Name = "SoundCloud")]
        public string scLink { get; set; }

        [Display(Name = "Live")]
        public string live { get; set; }
    }
}
