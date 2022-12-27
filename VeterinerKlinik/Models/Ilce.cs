using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Ilce
{
    public int IlceNo { get; set; }

    public string IlceAdi { get; set; } = null!;

    public int IlNo { get; set; }

    public virtual Il IlNoNavigation { get; set; } = null!;

    public virtual ICollection<Mahalle> Mahalles { get; } = new List<Mahalle>();
}
