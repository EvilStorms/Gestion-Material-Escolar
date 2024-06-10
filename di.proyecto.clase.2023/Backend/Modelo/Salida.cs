using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Salida
{
    public int Idsalida { get; set; }

    public int Usuario { get; set; }

    public int Articulo { get; set; }

    public DateTime Fechasalida { get; set; }

    public DateTime? Fechadevolucion { get; set; }

    public virtual Articulo ArticuloNavigation { get; set; } = null!;

    public virtual Usuario UsuarioNavigation { get; set; } = null!;
}
