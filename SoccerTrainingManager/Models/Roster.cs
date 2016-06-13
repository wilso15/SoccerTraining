using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoccerTrainingManager.Models
{
    public class Roster
    {
        [Key]
        public int ID { get; set; }
        public string Player { get; set; }
        public int Jersey { get; set; }
        public int Shots { get; set; }
        [Display(Name = "Shots On Target")]
        public int ShotsOnTarget { get; set; }
        public int Passes { get; set; }
        [Display(Name ="Passes Completed")]
        public int PassesCompleted { get; set; }
        public int Interceptions { get; set; }
        public int Dribbles { get; set; }
        [Display(Name = "Dribbles Completed")]
        public int DribblesCompleted { get; set; }
        public string Guardian { get; set; }
        [Display(Name = "Guardian Email")]
        public string GuardianEmail { get; set; }
    }
}