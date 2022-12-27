using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Klinik
{
    public int KlinikNo { get; set; }

    public string? Adi { get; set; }

    public int? AdresNo { get; set; }

    public virtual Adres? AdresNoNavigation { get; set; }

    public virtual ICollection<Kullanici> KullaniciNos { get; } = new List<Kullanici>();
}
