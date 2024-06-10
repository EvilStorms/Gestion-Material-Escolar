using System;
using System.Collections.Generic;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class Permisosrol
{
    /// <summary>
    /// Permisos asignados a cada rol
    /// </summary>
    public int Idpermisosrol { get; set; }

    public int Rol { get; set; }

    public int Permiso { get; set; }

    /// <summary>
    /// Indica si el permiso se permite, deniega o hereda. En caso de heredarse, se hereda del padre inmediato.
    /// 0: denegado
    /// 1: permitido
    /// 2: heredado
    /// </summary>
    public int? Acceso { get; set; }

    public virtual Permiso PermisoNavigation { get; set; } = null!;

    public virtual Rol RolNavigation { get; set; } = null!;
}
