using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class IletisimBilgileri
{
    public int No { get; set; }

    public string? TelNo { get; set; }

    public int KisiNo { get; set; }

    public int AdresNo { get; set; }

    public string Email { get; set; } = null!;

    public virtual Adres AdresNoNavigation { get; set; } = null!;
}
