using System;
using System.Collections.Generic;

namespace MC_MZ_PF_API.Data.Models;

public partial class Cultura
{
    public int Id { get; set; }

    public string AsuntoCul { get; set; } = null!;

    public string CuerpoCul { get; set; } = null!;

    public DateTime FechaCul { get; set; }
}
