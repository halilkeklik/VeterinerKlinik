using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Veteriner
{
    public int KisiNo { get; set; }

    public string Unvan { get; set; } = null!;

    public int? VekilNo { get; set; }

    public virtual ICollection<Asistan> Asistans { get; } = new List<Asistan>();

    public virtual ICollection<Veteriner> InverseVekilNoNavigation { get; } = new List<Veteriner>();

    public virtual Kullanici KisiNoNavigation { get; set; } = null!;

    public virtual ICollection<Randevu> Randevus { get; } = new List<Randevu>();

    public virtual Veteriner? VekilNoNavigation { get; set; }

    public virtual ICollection<Hasta> HastaNos { get; } = new List<Hasta>();
}
