using System;
using System.Collections.Generic;
using System.Text;

public class Class1
{

    [Key]
    public int UserId { get; set; }
    public int TrainingId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;


    public User user { get; set; }
    public Training training { get; set; }

}
