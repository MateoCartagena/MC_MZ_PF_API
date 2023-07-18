using System;
using System.Collections.Generic;

namespace MC_MZ_PF_API.Data.Models;

public partial class Arte
{
    public int Id { get; set; }

    public string AsuntoArt { get; set; } = null!;

    public string CuerpoArt { get; set; } = null!;

    public DateTime FechaArt { get; set; }
}
