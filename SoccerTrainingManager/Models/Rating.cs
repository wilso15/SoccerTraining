using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoccerTrainingManager.Models
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        public string StarRating { get; set; }
    }
}