using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Printing;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    /// <summary>
    /// Clase que implementa la interfaz de acceso a datos
    /// </summary>
    /// <typeparam name="T">Generica</typeparam>
    public class ServicioGenerico<T> : IServicioGenerico<T>
        where T : class
    {
        /// <summary>
        /// Objeto que accede a la capa de acceso a datos creada por Entity Framework
        /// </summary>
        private DbContext _entities;
        /// <summary>
        /// Objeto que nos permite acceder a las clases asociadas con las tablas de la base de datos
        /// </summary>
        private readonly DbSet<T> _dbset;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">objeto que nos permite acceder a las clases asociadas a la base de datos</param>
        public ServicioGenerico(DbContext context)
        {
            // Comprobamos que el parámetro no es nulo
            if(context == null) throw new ArgumentNullException("context");
            _entities = context;
            _dbset = context.Set<T>();
        }
        /// <summary>
        /// Inserta la entidad a la base de datos
        /// </summary>
        /// <param name="entity">Entidad para guardar</param>
        public bool Add(T entity)
        {
            bool correcto = true;
            try
            {
                // Comprobación de que la entidad no es nula
                if (entity == null)
                {
                    // Lanzamos la excepción
                    throw new ArgumentNullException("entity");
                }
                // Insertamos el objeto
                _entities.Add(entity);
                // Guardamos los cambios
                Save();
            }
            catch (DbUpdateException dbex)
            {
                // En caso de que se produzca una excepción se relanza
                correcto = false;
                throw dbex;
            }
            return correcto;
        }
        /// <summary>
        /// Realiza un borrado de un elemento de la base de datos
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        public void Delete(T entity)
        {
            try
            {
                // Comprobación de que la entidad no es nula
                if (entity == null)
                {
                    // Lanzamos la excepción
                    throw new ArgumentNullException("entity");
                }
                // Insertamos el objeto
                _entities.Remove(entity);
                // Guardamos los cambios
                Save();
            }
            catch (DbUpdateException dbex)
            {
                // En caso de que se produzca una excepción se relanza
                throw dbex;
            }
        }
        /// <summary>
        /// Devuelve una lista con todos los objetos de una tabla de la base de datos
        /// </summary>
        public List<T> GetAll { get{ return _dbset.AsEnumerable<T>().ToList(); } }
        /// <summary>
        /// Realiza un commit de la cache a la base de datos
        /// </summary>
        public void Save()
        {
            _entities.SaveChanges();
        }
        /// <summary>
        /// Devuelve un objeto identificado por su id
        /// </summary>
        /// <param name="id">Identificador del objeto</param>
        /// <returns>Devuelve el objeto que coincide con el id</returns>
        public T FindByID(int id)
        {
            // Devuelve la entidad en función del id
            return _dbset.Find(id);
        }
        /// <summary>
        /// Inserta o actualiza un objeto en la base de datos
        /// </summary>
        public bool AddOrUpdate(T entity)
        {
            bool correcto = true;
            try
            {
                // Comprobación de que la entidad no es nula
                if (entity == null)
                {
                    // Lanzamos la excepción
                    throw new ArgumentNullException("entity");
                }
                // Insertamos el objeto
                _entities.Update(entity);
                // Guardamos los cambios
                Save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
                // En caso de que se produzca una excepción se relanza
                throw dbex;
            }
            return correcto;
        }
        /// <summary>
        /// Devuelve una lista de obketos que cumplen el criterio
        /// </summary>
        /// <param name="predicate">Criterio que deben de cumplir los objetos</param>
        /// <returns>Lista con los objetos que cumplen con el criterio</returns>
        public List<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            if(predicate == null) { throw new ArgumentNullException("predicado nulo"); }
            List<T> query = _dbset.Where(predicate).AsEnumerable().ToList();
            return query;
        }
    }
}
