using Microsoft.EntityFrameworkCore;

namespace di.proyecto.clase._2023.Backend.Modelo;

public partial class DiInventario : DbContext
{
    public DiInventario()
    {
    }

    public DiInventario(DbContextOptions<DiInventario> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Espacio> Espacios { get; set; }

    public virtual DbSet<Ficheromodelo> Ficheromodelos { get; set; }

    public virtual DbSet<Ficherousuario> Ficherousuarios { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Modeloarticulo> Modeloarticulos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Permisosrol> Permisosrols { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Salida> Salida { get; set; }

    public virtual DbSet<Tipoarticulo> Tipoarticulos { get; set; }

    public virtual DbSet<Tipousuario> Tipousuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=127.0.0.1;port=3306;database=diinventarioexamen;user=root;password=mysql", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.30-mysql"));


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Idarticulo).HasName("PRIMARY");

            entity.ToTable("articulo");

            entity.HasIndex(e => e.Departamento, "fk_departamentos_articulo_idx");

            entity.HasIndex(e => e.Espacio, "fk_espacios_articulo_idx");

            entity.HasIndex(e => e.Dentrode, "fk_estaen_articulo_idx");

            entity.HasIndex(e => e.Modelo, "fk_modelos_articulo_idx");

            entity.HasIndex(e => e.Usuarioalta, "fk_usuarioalta_articulo_idx");

            entity.HasIndex(e => e.Usuariobaja, "fk_usuariobaja_modeloarticulo_idx");

            entity.Property(e => e.Idarticulo)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idarticulo");
            entity.Property(e => e.Dentrode)
                .HasComment("Indica que este artículo forma parte de otro")
                .HasColumnType("int(11)")
                .HasColumnName("dentrode");
            entity.Property(e => e.Departamento)
                .HasComment("departamento al que pertenece o del que depende")
                .HasColumnType("int(11)")
                .HasColumnName("departamento");
            entity.Property(e => e.Espacio)
                .HasComment("espacio en que se encuentra")
                .HasColumnType("int(11)")
                .HasColumnName("espacio");
            entity.Property(e => e.Estado)
                .HasMaxLength(45)
                .HasColumnName("estado");
            entity.Property(e => e.Fechaalta)
                .HasComment("fecha en que se introdujo en el sistema")
                .HasColumnName("fechaalta");
            entity.Property(e => e.Fechabaja).HasColumnName("fechabaja");
            entity.Property(e => e.Modelo)
                .HasColumnType("int(11)")
                .HasColumnName("modelo");
            entity.Property(e => e.Numserie)
                .HasMaxLength(45)
                .HasColumnName("numserie");
            entity.Property(e => e.Observaciones)
                .HasColumnType("mediumtext")
                .HasColumnName("observaciones");
            entity.Property(e => e.Usuarioalta)
                .HasColumnType("int(11)")
                .HasColumnName("usuarioalta");
            entity.Property(e => e.Usuariobaja)
                .HasComment("usuario que lo dio de baja")
                .HasColumnType("int(11)")
                .HasColumnName("usuariobaja");

            entity.HasOne(d => d.DentrodeNavigation).WithMany(p => p.InverseDentrodeNavigation)
                .HasForeignKey(d => d.Dentrode)
                .HasConstraintName("fk_dentrode_articulo");

            entity.HasOne(d => d.DepartamentoNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Departamento)
                .HasConstraintName("fk_departamentos_articulo");

            entity.HasOne(d => d.EspacioNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Espacio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_espacios_articulo");

            entity.HasOne(d => d.ModeloNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Modelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_modelos_articulo");

            entity.HasOne(d => d.UsuarioaltaNavigation).WithMany(p => p.ArticuloUsuarioaltaNavigations)
                .HasForeignKey(d => d.Usuarioalta)
                .HasConstraintName("fk_usuarioalta_articulo");

            entity.HasOne(d => d.UsuariobajaNavigation).WithMany(p => p.ArticuloUsuariobajaNavigations)
                .HasForeignKey(d => d.Usuariobaja)
                .HasConstraintName("fk_usuariobaja_articulo");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Iddepartamento).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.HasIndex(e => e.Nombre, "nombre_UNIQUE").IsUnique();

            entity.Property(e => e.Iddepartamento)
                .HasComment("Departamentos del instituto")
                .HasColumnType("int(11)")
                .HasColumnName("iddepartamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Espacio>(entity =>
        {
            entity.HasKey(e => e.Idespacio).HasName("PRIMARY");

            entity.ToTable("espacio");

            entity.HasIndex(e => e.Padre, "fk_espacios_espacio_idx");

            entity.HasIndex(e => e.Nombre, "nombre_UNIQUE").IsUnique();

            entity.Property(e => e.Idespacio)
                .ValueGeneratedNever()
                .HasComment("Cualquier lugar en el que se puede encontrar un artículo.\nUnos espacios pueden estar dentro de otros: relación jerárquica")
                .HasColumnType("int(11)")
                .HasColumnName("idespacio");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .HasColumnName("nombre");
            entity.Property(e => e.Padre)
                .HasColumnType("int(11)")
                .HasColumnName("padre");

            entity.HasOne(d => d.PadreNavigation).WithMany(p => p.InversePadreNavigation)
                .HasForeignKey(d => d.Padre)
                .HasConstraintName("fk_espacios_espacio");
        });

        modelBuilder.Entity<Ficheromodelo>(entity =>
        {
            entity.HasKey(e => e.Idficheromodelo).HasName("PRIMARY");

            entity.ToTable("ficheromodelo");

            entity.HasIndex(e => e.Modelo, "fk_modelos_ficheromodelo_idx");

            entity.Property(e => e.Idficheromodelo)
                .ValueGeneratedNever()
                .HasComment("Permite asociar ficheros a cada modelo de articulo")
                .HasColumnType("int(11)")
                .HasColumnName("idficheromodelo");
            entity.Property(e => e.Contenido)
                .HasColumnType("blob")
                .HasColumnName("contenido");
            entity.Property(e => e.Modelo)
                .HasComment("Modelo al que pertenece")
                .HasColumnType("int(11)")
                .HasColumnName("modelo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasComment("Nombre del fichero")
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasComment("tipo de informacion que contiene")
                .HasColumnName("tipo");

            entity.HasOne(d => d.ModeloNavigation).WithMany(p => p.Ficheromodelos)
                .HasForeignKey(d => d.Modelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_modelos_ficheromodelo");
        });

        modelBuilder.Entity<Ficherousuario>(entity =>
        {
            entity.HasKey(e => e.Idficherousuario).HasName("PRIMARY");

            entity.ToTable("ficherousuario");

            entity.HasIndex(e => e.Usuario, "fk_usuarios_ficherousuario_idx");

            entity.Property(e => e.Idficherousuario)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idficherousuario");
            entity.Property(e => e.Contenido)
                .HasColumnType("blob")
                .HasColumnName("contenido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasComment("nombre del fichero")
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .HasComment("tipo de informacion que contiene")
                .HasColumnName("tipo");
            entity.Property(e => e.Usuario)
                .HasComment("usuario al que pertenece el fichero")
                .HasColumnType("int(11)")
                .HasColumnName("usuario");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Ficherousuarios)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuarios_ficherousuario");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Idgrupo).HasName("PRIMARY");

            entity.ToTable("grupo");

            entity.HasIndex(e => e.Nombre, "nombre_UNIQUE").IsUnique();

            entity.Property(e => e.Idgrupo)
                .HasMaxLength(10)
                .HasComment("grupos de clase")
                .HasColumnName("idgrupo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Modeloarticulo>(entity =>
        {
            entity.HasKey(e => e.Idmodeloarticulo).HasName("PRIMARY");

            entity.ToTable("modeloarticulo");

            entity.HasIndex(e => e.Tipo, "fk_tipoarticulos_modeloarticulo_idx");

            entity.Property(e => e.Idmodeloarticulo)
                .HasComment("Es un catalogo de articulos existentes. De cada modelo puede haber varias unidades con distintos numeros de serie, etc")
                .HasColumnType("int(11)")
                .HasColumnName("idmodeloarticulo");
            entity.Property(e => e.Descripcion)
                .HasColumnType("mediumtext")
                .HasColumnName("descripcion");
            entity.Property(e => e.Marca)
                .HasMaxLength(255)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(255)
                .HasColumnName("modelo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasColumnType("int(11)")
                .HasColumnName("tipo");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Modeloarticulos)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("fk_tipoarticulos_modeloarticulo");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Idpermiso).HasName("PRIMARY");

            entity.ToTable("permiso");

            entity.HasIndex(e => e.Permisopadre, "fk_permisos_padre_idx");

            entity.HasIndex(e => e.Nombre, "nombre_UNIQUE").IsUnique();

            entity.Property(e => e.Idpermiso)
                .HasComment("Las distintas acciones que se pueden realizar sobre las entidades que maneja la aplicacion\n")
                .HasColumnType("int(11)")
                .HasColumnName("idpermiso");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Permisopadre)
                .HasComment("Permite jerarquizar los permisos de manera que unos dependand de otros.\n\nAqui se indica el id del permiso del que depende o nul si es independiente\n\nPor ejemplo \"alta de usuario\" y \"baja de usuario\" pueden depender de \"acceso a usuarios\"")
                .HasColumnType("int(11)")
                .HasColumnName("permisopadre");

            entity.HasOne(d => d.PermisopadreNavigation).WithMany(p => p.InversePermisopadreNavigation)
                .HasForeignKey(d => d.Permisopadre)
                .HasConstraintName("fk_permisos_padre");
        });

        modelBuilder.Entity<Permisosrol>(entity =>
        {
            entity.HasKey(e => e.Idpermisosrol).HasName("PRIMARY");

            entity.ToTable("permisosrol");

            entity.HasIndex(e => e.Permiso, "fk_permisos_permisosrol_idx");

            entity.HasIndex(e => e.Rol, "fk_roles_permisosrol_idx");

            entity.Property(e => e.Idpermisosrol)
                .ValueGeneratedNever()
                .HasComment("Permisos asignados a cada rol")
                .HasColumnType("int(11)")
                .HasColumnName("idpermisosrol");
            entity.Property(e => e.Acceso)
                .HasDefaultValueSql("'0'")
                .HasComment("Indica si el permiso se permite, deniega o hereda. En caso de heredarse, se hereda del padre inmediato.\n0: denegado\n1: permitido\n2: heredado")
                .HasColumnType("int(11)")
                .HasColumnName("acceso");
            entity.Property(e => e.Permiso)
                .HasColumnType("int(11)")
                .HasColumnName("permiso");
            entity.Property(e => e.Rol)
                .HasColumnType("int(11)")
                .HasColumnName("rol");

            entity.HasOne(d => d.PermisoNavigation).WithMany(p => p.Permisosrols)
                .HasForeignKey(d => d.Permiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_permisos_permisosrol");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Permisosrols)
                .HasForeignKey(d => d.Rol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_roles_permisosrol");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.HasIndex(e => e.Nombre, "nombre_UNIQUE").IsUnique();

            entity.Property(e => e.Idrol)
                .HasComment("Roles que juegan los usuarios de la aplicacion")
                .HasColumnType("int(11)")
                .HasColumnName("idrol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Salida>(entity =>
        {
            entity.HasKey(e => e.Idsalida).HasName("PRIMARY");

            entity.ToTable("salida");

            entity.HasIndex(e => e.Articulo, "fk_articulos_salida_idx");

            entity.HasIndex(e => e.Usuario, "fk_usuarios_salida_idx");

            entity.Property(e => e.Idsalida)
                .HasColumnType("int(11)")
                .HasColumnName("idsalida");
            entity.Property(e => e.Articulo)
                .HasColumnType("int(11)")
                .HasColumnName("articulo");
            entity.Property(e => e.Fechadevolucion)
                .HasColumnType("datetime")
                .HasColumnName("fechadevolucion");
            entity.Property(e => e.Fechasalida)
                .HasColumnType("datetime")
                .HasColumnName("fechasalida");
            entity.Property(e => e.Usuario)
                .HasColumnType("int(11)")
                .HasColumnName("usuario");

            entity.HasOne(d => d.ArticuloNavigation).WithMany(p => p.Salida)
                .HasForeignKey(d => d.Articulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_articulos_salida");

            entity.HasOne(d => d.UsuarioNavigation).WithMany(p => p.Salida)
                .HasForeignKey(d => d.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuarios_salida");
        });

        modelBuilder.Entity<Tipoarticulo>(entity =>
        {
            entity.HasKey(e => e.Idtipoarticulo).HasName("PRIMARY");

            entity.ToTable("tipoarticulo");

            entity.HasIndex(e => e.Padre, "fk_padre_tipoarticulo_idx");

            entity.Property(e => e.Idtipoarticulo)
                .HasComment("tipos de articulo: relacion jerárquica\\nMobiliario\\n- Mesa\\n -- Mesa despacho\\n...")
                .HasColumnType("int(11)")
                .HasColumnName("idtipoarticulo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Padre)
                .HasComment("tipo de articulo del que depende: relacion jerarquica")
                .HasColumnType("int(11)")
                .HasColumnName("padre");

            entity.HasOne(d => d.PadreNavigation).WithMany(p => p.InversePadreNavigation)
                .HasForeignKey(d => d.Padre)
                .HasConstraintName("fk_padre_tipoarticulo");
        });

        modelBuilder.Entity<Tipousuario>(entity =>
        {
            entity.HasKey(e => e.Idtipousuario).HasName("PRIMARY");

            entity.ToTable("tipousuario");

            entity.HasIndex(e => e.Nombre, "nombre_UNIQUE").IsUnique();

            entity.Property(e => e.Idtipousuario)
                .HasComment("Para diferenciar tipos de usuario, independientemente del rol que juegan, y poder hacer operaciones masivas con ellos: alumnos, profesores, pas, ...")
                .HasColumnType("int(11)")
                .HasColumnName("idtipousuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasComment("descripción del tipo de usuario")
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Departamento, "fk_departamentos_usuario_idx");

            entity.HasIndex(e => e.Grupo, "fk_grupos_usuario_idx");

            entity.HasIndex(e => e.Rol, "fk_roles_usuario_idx");

            entity.HasIndex(e => e.Tipo, "fk_tipos_usuario_idx");

            entity.HasIndex(e => e.Username, "username_UNIQUE").IsUnique();

            entity.Property(e => e.Idusuario)
                .HasColumnType("int(11)")
                .HasColumnName("idusuario");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(45)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(45)
                .HasColumnName("apellido2");
            entity.Property(e => e.Codpostal)
                .HasMaxLength(10)
                .HasColumnName("codpostal");
            entity.Property(e => e.Departamento)
                .HasColumnType("int(11)")
                .HasColumnName("departamento");
            entity.Property(e => e.Domicilio)
                .HasMaxLength(45)
                .HasColumnName("domicilio");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Grupo)
                .HasMaxLength(10)
                .HasColumnName("grupo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .HasColumnName("password");
            entity.Property(e => e.Poblacion)
                .HasMaxLength(45)
                .HasColumnName("poblacion");
            entity.Property(e => e.Rol)
                .HasColumnType("int(11)")
                .HasColumnName("rol");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.Tipo)
                .HasColumnType("int(11)")
                .HasColumnName("tipo");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasComment("Usuarios de la aplicacion\n")
                .HasColumnName("username");

            entity.HasOne(d => d.DepartamentoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Departamento)
                .HasConstraintName("fk_departamentos_usuario");

            entity.HasOne(d => d.GrupoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Grupo)
                .HasConstraintName("fk_grupos_usuario");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Rol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_roles_usuario");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Tipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipos_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
