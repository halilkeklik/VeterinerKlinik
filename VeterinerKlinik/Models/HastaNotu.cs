using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class HastaNotu
{
    public int No { get; set; }

    public int HastaNo { get; set; }

    public int RandevuNo { get; set; }

    public string Not { get; set; } = null!;

    public DateTime Tarih { get; set; }

    public virtual Hasta HastaNoNavigation { get; set; } = null!;

    public virtual Randevu RandevuNoNavigation { get; set; } = null!;
}
