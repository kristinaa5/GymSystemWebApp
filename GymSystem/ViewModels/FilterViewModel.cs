using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymSystem.ViewModels
{
     public class FilterViewModel
    {

        [Display(Name = "Pol")]
        public string gender { get; set; }
        [Display(Name = "Adresa")]
        public string address { get; set; }
        [Display(Name = "Datum treninga")]
        public DateTime date { get; set; }

    }
}
