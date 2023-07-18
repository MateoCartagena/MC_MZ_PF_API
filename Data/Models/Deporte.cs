using System;
using System.Collections.Generic;

namespace MC_MZ_PF_API.Data.Models;

public partial class Deporte
{
    public int Id { get; set; }

    public string AsuntoDep { get; set; } = null!;

    public string CuerpoDep { get; set; } = null!;

    public DateTime FechaDep { get; set; }
}
