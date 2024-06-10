using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Tipoarticulo
{
    /// <summary>
    /// tipos de articulo: relacion jerárquica\nMobiliario\n- Mesa\n -- Mesa despacho\n...
    /// </summary>
    public int Idtipoarticulo { get; set; }

    public string Nombre { get; set; } = null!;

    /// <summary>
    /// tipo de articulo del que depende: relacion jerarquica
    /// </summary>
    public int? Padre { get; set; }

    public virtual ICollection<Tipoarticulo> InversePadreNavigation { get; set; } = new List<Tipoarticulo>();

    public virtual ICollection<Modeloarticulo> Modeloarticulos { get; set; } = new List<Modeloarticulo>();

    public virtual Tipoarticulo? PadreNavigation { get; set; }
}
