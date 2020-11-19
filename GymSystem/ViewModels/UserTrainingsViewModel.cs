using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymSystem.ViewModels
{
   public class UserTrainingsViewModel
    {
        [Display(Name = "Korisnik")]
        public string Name { get; set; }
        [Display(Name = "Adresa")]
        public string Address { get; set; }
        [Display(Name = "Datum i vreme")]
        public DateTime Date { get; set; }
    }
}
