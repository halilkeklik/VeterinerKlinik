using System.Collections.Generic;

namespace VeterinerKlinik.Models;

public partial class Adres
{
    public int AdresNo { get; set; }

    public string adres { get; set; } = null!;

    public int MahalleNo { get; set; }

    public virtual ICollection<IletisimBilgileri> IletisimBilgileris { get; } = new List<IletisimBilgileri>();

    public virtual ICollection<Klinik> Kliniks { get; } = new List<Klinik>();

    public virtual Mahalle MahalleNoNavigation { get; set; } = null!;
}
