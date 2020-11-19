using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymSystem.Models
{
   public class Training
    {

        [Key]
        public int TrainingId { get; set; }

        [Display(Name = "Datum treninga")]
        [Required(ErrorMessage = "Polje Datum je obavezno")]
        public DateTime Date { get; set; }

        [Display(Name = "Slobodan termin")]
        public bool Free { get; set; }


        public List<UserTraining> userTrainings { get; set; }
    }
}
