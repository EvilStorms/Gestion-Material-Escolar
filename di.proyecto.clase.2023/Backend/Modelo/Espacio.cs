using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Espacio
{
    /// <summary>
    /// Cualquier lugar en el que se puede encontrar un artículo.
    /// Unos espacios pueden estar dentro de otros: relación jerárquica
    /// </summary>
    public int Idespacio { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? Padre { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

    public virtual ICollection<Espacio> InversePadreNavigation { get; set; } = new List<Espacio>();

    public virtual Espacio? PadreNavigation { get; set; }
}
