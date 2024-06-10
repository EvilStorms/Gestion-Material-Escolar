using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Grupo
{
    /// <summary>
    /// grupos de clase
    /// </summary>
    public string Idgrupo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
