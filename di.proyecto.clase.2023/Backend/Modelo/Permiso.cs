using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Permiso
{
    /// <summary>
    /// Las distintas acciones que se pueden realizar sobre las entidades que maneja la aplicacion
    /// 
    /// </summary>
    public int Idpermiso { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    /// <summary>
    /// Permite jerarquizar los permisos de manera que unos dependand de otros.
    /// 
    /// Aqui se indica el id del permiso del que depende o nul si es independiente
    /// 
    /// Por ejemplo &quot;alta de usuario&quot; y &quot;baja de usuario&quot; pueden depender de &quot;acceso a usuarios&quot;
    /// </summary>
    public int? Permisopadre { get; set; }

    public virtual ICollection<Permiso> InversePermisopadreNavigation { get; set; } = new List<Permiso>();

    public virtual Permiso? PermisopadreNavigation { get; set; }

    public virtual ICollection<Permisosrol> Permisosrols { get; set; } = new List<Permisosrol>();
}
