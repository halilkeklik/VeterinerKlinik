using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Mahalle
{
    public int MahalleNo { get; set; }

    public string MahalleAdi { get; set; } = null!;

    public int IlceNo { get; set; }

    public virtual ICollection<Adres> Adres { get; } = new List<Adres>();

    public virtual Ilce IlceNoNavigation { get; set; } = null!;
}
