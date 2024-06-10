using di.proyecto.clase._2023.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Modeloarticulo : PropertyChangedDataError
{
    /// <summary>
    /// Es un catalogo de articulos existentes. De cada modelo puede haber varias unidades con distintos numeros de serie, etc
    /// </summary>

    
    public int Idmodeloarticulo { get; set; }
    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Tipo { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

    public virtual ICollection<Ficheromodelo> Ficheromodelos { get; set; } = new List<Ficheromodelo>();

    public virtual Tipoarticulo? TipoNavigation { get; set; }
}
