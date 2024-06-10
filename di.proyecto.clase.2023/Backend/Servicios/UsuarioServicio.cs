using di.proyecto.clase._2023.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    /*
     * Clase que contiene las reglas de negocio propias de la tabla usuario
     */
    public class UsuarioServicio : ServicioGenerico<Usuario>
    {
        private DiInventario contexto;
        private const int PROFESOR = 1;
        /*
         * Se almacena el usuario que ha iniciado sesión
         */
        public Usuario usuLogin { get; set; }
        /*
         * Constructor 
         */
        public UsuarioServicio(DiInventario context) : base(context)
        {
            contexto = context;
        }
        /*
         * Método que comprueba las credenciales del usuario en la base de datos
         */
        public Boolean login(String user, String pass)
        {
            Boolean correcto = true;
            try
            {
                usuLogin = contexto.Set<Usuario>().Where(u => u.Username == user).FirstOrDefault();
            } catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
            if(usuLogin == null)
            {
                correcto = false;
            } else if (!usuLogin.Username.Equals(user) || !usuLogin.Password.Equals(pass))
            {
                correcto = false;
            }
            
            return correcto;
        }       
        /*
         * Comprueba si en la base de datos existe un usuario con ese login
         * El login de un usuario debe de ser único
         */
        public Boolean usuarioUnico(string usu)
        {
            bool unico = true;
            if(contexto.Set<Usuario>().Where(u => u.Username == usu).Count() > 0)
            {
                unico = false;
            }
            return unico;
        }
        /*
         * Devuelve un usuario en función del username pasado
         */
        public Usuario getUsuarioPorNombre(string nom)
        {
            Usuario usu;
            usu = contexto.Set<Usuario>().Where(u => u.Username == nom).FirstOrDefault();
            return usu;
        }

        public List<Usuario> getProfesores()
        {
            return contexto.Set<Usuario>().Where(u => u.Tipo == PROFESOR).ToList();
        }
    }
}