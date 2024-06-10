using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Usuario
{
    public int Idusuario { get; set; }

    /// <summary>
    /// Usuarios de la aplicacion
    /// 
    /// </summary>
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Tipo { get; set; }

    public int Rol { get; set; }

    public string? Grupo { get; set; }

    public int? Departamento { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public string? Domicilio { get; set; }

    public string? Poblacion { get; set; }

    public string? Codpostal { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Articulo> ArticuloUsuarioaltaNavigations { get; set; } = new List<Articulo>();

    public virtual ICollection<Articulo> ArticuloUsuariobajaNavigations { get; set; } = new List<Articulo>();

    public virtual Departamento? DepartamentoNavigation { get; set; }

    public virtual ICollection<Ficherousuario> Ficherousuarios { get; set; } = new List<Ficherousuario>();

    public virtual Grupo? GrupoNavigation { get; set; }

    public virtual Rol RolNavigation { get; set; } = null!;

    public virtual ICollection<Salida> Salida { get; set; } = new List<Salida>();

    public virtual Tipousuario TipoNavigation { get; set; } = null!;

    override public string ToString()
    {
        return Nombre + " " + Apellido1 + " (" + Username + ")";
    }
}
