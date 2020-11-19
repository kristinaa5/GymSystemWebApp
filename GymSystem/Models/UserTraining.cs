using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymSystem.Models
{
   public class UserTraining
    {
        [Key]
        public int Id { get; set; }
       [Display (Name ="Korisnik")]
        public int UserId { get; set; }
        [Display(Name = "Trening")]
        public int TrainingId { get; set; }
        [Display(Name = "Datum i vreme")]
        public DateTime Timestamp { get; set; } = DateTime.Now;
        


        public User user { get; set; }
        public Training training { get; set; }
    }
}
