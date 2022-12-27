using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Cin
{
    public int CinsNo { get; set; }

    public string CinsAdi { get; set; } = null!;

    public int TurNo { get; set; }

    public virtual ICollection<Hastum> Hasta { get; } = new List<Hastum>();
}
