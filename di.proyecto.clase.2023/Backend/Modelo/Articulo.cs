using di.proyecto.clase._2023.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Articulo: PropertyChangedDataError
{
    public int Idarticulo { get; set; }
    
    public string? Numserie { get; set; }

    public string? Estado { get; set; }

    /// <summary>
    /// fecha en que se introdujo en el sistema
    /// </summary>
    public DateTime? Fechaalta { get; set; }

    public DateTime? Fechabaja { get; set; }

    public int? Usuarioalta { get; set; }

    /// <summary>
    /// usuario que lo dio de baja
    /// </summary>
    public int? Usuariobaja { get; set; }

    public int Modelo { get; set; }

    /// <summary>
    /// departamento al que pertenece o del que depende
    /// </summary>
    public int? Departamento { get; set; }

    /// <summary>
    /// espacio en que se encuentra
    /// </summary>
    public int Espacio { get; set; }

    /// <summary>
    /// Indica que este artículo forma parte de otro
    /// </summary>
    public int? Dentrode { get; set; }

    [Required]
    public string? Observaciones { get; set; }

    public virtual Articulo? DentrodeNavigation { get; set; }
    
    public virtual Departamento? DepartamentoNavigation { get; set; }
    [Required]
    public virtual Espacio EspacioNavigation { get; set; } = null!;

    public virtual ICollection<Articulo> InverseDentrodeNavigation { get; set; } = new List<Articulo>();
    [Required]
    public virtual Modeloarticulo ModeloNavigation { get; set; } = null!;

    public virtual ICollection<Salida> Salida { get; set; } = new List<Salida>();

    public virtual Usuario? UsuarioaltaNavigation { get; set; }

    public virtual Usuario? UsuariobajaNavigation { get; set; }
}
