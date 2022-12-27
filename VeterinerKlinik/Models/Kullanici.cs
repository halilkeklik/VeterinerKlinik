using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Kullanici
{
    public int KullaniciNo { get; set; }

    public string Adi { get; set; } = null!;

    public string SoyAdi { get; set; } = null!;

    public string KullaniciAdi { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public bool? Aktif { get; set; }

    public virtual Asistan? Asistan { get; set; }

    public virtual Musteri? Musteri { get; set; }

    public virtual Veteriner? Veteriner { get; set; }

    public virtual ICollection<Klinik> KlinikNos { get; } = new List<Klinik>();
}
