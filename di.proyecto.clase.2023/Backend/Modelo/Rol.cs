using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Rol
{
    /// <summary>
    /// Roles que juegan los usuarios de la aplicacion
    /// </summary>
    public int Idrol { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Permisosrol> Permisosrols { get; set; } = new List<Permisosrol>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
