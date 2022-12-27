using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Asistan
{
    public int KisiNo { get; set; }

    public int VeterinerNo { get; set; }

    public virtual Kullanici KisiNoNavigation { get; set; } = null!;

    public virtual Veteriner VeterinerNoNavigation { get; set; } = null!;
}
