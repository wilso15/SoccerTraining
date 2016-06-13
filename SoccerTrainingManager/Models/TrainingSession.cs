using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoccerTrainingManager.Models
{
    public class TrainingSession
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Warm-up")]
        public string WarmUp { get; set; }
        [Display(Name = "Technical Drill")]
        public string TechnicalDrill { get; set; }
        [Display(Name = "Possession Drill")]
        public string PossessionDrill { get; set; }
        [Display(Name = "Shooting Drill")]
        public string ShootingDrill { get; set; }
        public string Fitness { get; set; }
        [Display(Name = "Star Rating")]
        public string Rating { get; set; }

    }
}