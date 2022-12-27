using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Hasta
{
    public int HastaNo { get; set; }

    public string? Adi { get; set; }

    public int? Cins { get; set; }

    public int MusteriNo { get; set; }

    public int? Yas { get; set; }

    public bool? Aktif { get; set; }

    public int? Tur { get; set; }

    public int? DogumYili { get; set; }

    public virtual Cins? CinsNavigation { get; set; }

    public virtual ICollection<HastaNotu> HastaNotus { get; } = new List<HastaNotu>();

    public virtual Musteri MusteriNoNavigation { get; set; } = null!;

    public virtual ICollection<Randevu> Randevus { get; } = new List<Randevu>();

    public virtual ICollection<Veteriner> VeterinerNos { get; } = new List<Veteriner>();
}
