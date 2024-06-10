using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2023.Backend.Servicios
{
    /*
     * Interfaz que nos muestra las principales operaciones a realizar con los objetos 
     * de la base de datos
     */
    interface IServicioGenerico<T> where T : class
    {
        /// <summary>
        /// Obtiene todos los objetos de una determinada entidad
        /// </summary>
        List<T> GetAll { get; }
        /// <summary>
        /// Busca elementos según la expresión o predicado pasado como parámetro
        /// </summary>
        /// <param name="predicate">Predicado que expresa la condición</param>
        /// <returns>Lista con los objetos que cumplen la condición</returns>
        List<T> FindBy(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Busca un objeto por su identificador
        /// </summary>
        /// <param name="id">Identificador del objeto</param>
        /// <returns>Entidad cuyo id coincide con el parámetro</returns>
        T FindByID(int id);
        /// <summary>
        /// Inserta un objeto nuevo en la base de datos
        /// </summary>
        /// <param name="entity">Entidad a insertar</param>
        bool Add(T entity);
        /// <summary>
        /// Borra un objeto de la base de datos en función de su id
        /// </summary>
        /// <param name="entity">Entidad a borrar</param>
        void Delete(T entity);
        /// <summary>
        /// Realiza un commit para que los cambios se hagan persistentes
        /// </summary>
        void Save();
        /// <summary>
        /// Inserta o actualiza un objeto
        /// </summary>
        bool AddOrUpdate(T entity);
    }
}
