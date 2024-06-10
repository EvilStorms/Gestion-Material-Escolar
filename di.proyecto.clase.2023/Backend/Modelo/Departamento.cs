using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Departamento
{
    /// <summary>
    /// Departamentos del instituto
    /// </summary>
    public int Iddepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
