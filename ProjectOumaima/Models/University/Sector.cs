using System;
using System.Collections.Generic;

namespace ProjectOumaima.Models.University;

public partial class Sector
{
    public Sector() { 
        Students = new HashSet<Student>();  
    }
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Level { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } 
}
