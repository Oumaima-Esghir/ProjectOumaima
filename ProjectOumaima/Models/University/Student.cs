using System;
using System.Collections.Generic;

namespace ProjectOumaima.Models.University;

public partial class Student
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Niveau { get; set; } = null!;

    public int SectorId { get; set; }

    public virtual Sector? Sector { get; set; } = null!;
}
