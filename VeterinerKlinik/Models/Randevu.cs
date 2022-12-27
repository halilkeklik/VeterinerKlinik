using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Randevu
{
    public int RandevuNo { get; set; }

    public int VeterinerNo { get; set; }

    public int HastaNo { get; set; }

    public string? VeterinerNot { get; set; }

    public DateTime Tarih { get; set; }

    public string Durum { get; set; } = null!;

    public virtual Hasta HastaNoNavigation { get; set; } = null!;

    public virtual ICollection<HastaNotu> HastaNotus { get; } = new List<HastaNotu>();

    public virtual Veteriner VeterinerNoNavigation { get; set; } = null!;
}
