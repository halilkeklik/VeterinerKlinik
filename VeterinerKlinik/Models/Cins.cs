using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Cins
{
    public int CinsNo { get; set; }

    public string CinsAdi { get; set; } = null!;

    public int TurNo { get; set; }

    public virtual ICollection<Hasta> Hasta { get; } = new List<Hasta>();
}
