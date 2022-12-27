using System;
using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Il
{
    public int IlNo { get; set; }

    public string IlAdi { get; set; } = null!;

    public virtual ICollection<Ilce> Ilces { get; } = new List<Ilce>();
}
