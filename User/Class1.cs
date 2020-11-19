using System;
using System.ComponentModel.DataAnnotations;

namespace User
{
    public class Class1
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

    }
}
