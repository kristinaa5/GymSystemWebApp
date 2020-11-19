using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text;

namespace GymSystem.Models
{
   public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ime")]
        [Required (ErrorMessage ="Polje Ime je obavezno")]
        public string Name { get; set; }

        [Display(Name="Telefon")]
        [Required(ErrorMessage = "Polje Telefon je obavezno")]
        public string Phone { get; set; }

        [Display(Name = "Datum rodjenja")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Adresa")]
        [Required(ErrorMessage = "Polje Adresa je obavezno")]
        public string Address { get; set; }

        [Display(Name = "Pol")]
        public string Gender { get; set; }


        public List<UserTraining> userTrainings { get; set; }
        
    }
}
