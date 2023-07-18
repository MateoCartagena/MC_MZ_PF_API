using System;
using System.Collections.Generic;

namespace MC_MZ_PF_API.Data.Models;

public partial class Tecnologia
{
    public int Id { get; set; }

    public string AsuntoTec { get; set; } = null!;

    public string CuerpoTec { get; set; } = null!;

    public DateTime FechaTec { get; set; }
}
