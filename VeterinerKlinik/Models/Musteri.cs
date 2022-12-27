using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Musteri
{
    public int KisiNo { get; set; }

    public string? SigortaNo { get; set; }

    public virtual ICollection<Hasta> Hasta { get; } = new List<Hasta>();

    public virtual Kullanici KisiNoNavigation { get; set; } = null!;
}
