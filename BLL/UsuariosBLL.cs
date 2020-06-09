using System;
using System.Collections.Generic;
using System.Text;
//No olvidar Agregar los siguientes [using].
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using RegistroUsuarios.DAL; //Nombre del proyecto.DAL
using RegistroUsuarios.Entidades; //Nombre del proyecto.Entidades

namespace RegistroUsuarios.BLL //Nombre del proyecto.BLL
{
    public class UsuariosBLL //No olvidar agregarle [public] a la clase.
    {
        //——————————————————————————————————————————————[ GUARDAR ]——————————————————————————————————————————————
        // Permite insertar o modificar una entidad en la base de datos
        /// <param name="usuarios">La entidad que se desea guardar</param>
        public static bool Guardar(Usuarios usuarios)
        {
            if (!Existe(usuarios.UsuarioId)) //si no existe insertamos
                return Insertar(usuarios);
            else
                return Modificar(usuarios);
        }
        //——————————————————————————————————————————————[ INSERTAR ]——————————————————————————————————————————————
        // Permite insertar una entidad en la base de datos
        /// <param name="usuarios">La entidad que se desea guardar</param>
        private static bool Insertar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Usuarios.Add(usuarios);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //——————————————————————————————————————————————[ MODIFICAR ]——————————————————————————————————————————————
        // Permite modificar una entidad en la base de datos
        /// <param name="usuarios">La entidad que se desea modificar</param> 
        public static bool Modificar(Usuarios usuarios)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(usuarios).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //——————————————————————————————————————————————[ ELIMINAR ]——————————————————————————————————————————————
        // Permite eliminar una entidad de la base de datos
        /// <param name="id">El Id de la entidad que se desea eliminar</param> 
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var usuarios = contexto.Usuarios.Find(id);
                if (usuarios != null)
                {
                    contexto.Usuarios.Remove(usuarios);//remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //——————————————————————————————————————————————[ BUSCAR ]——————————————————————————————————————————————
        // Permite buscar una entidad en la base de datos
        /// <param name="id">El Id de la entidad que se desea buscar</param> 
        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuarios;
            try
            {
                usuarios = contexto.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuarios;
        }
        //——————————————————————————————————————————————[ GETLIST ]——————————————————————————————————————————————
        // Permite obtener una lista filtrada por un criterio de busqueda
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto contexto = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = contexto.Usuarios.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        //——————————————————————————————————————————————[ EXISTE ]——————————————————————————————————————————————
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Usuarios.Any(d => d.UsuarioId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        //——————————————————————————————————————————————[ GET "Nombre de la clase" ]——————————————————————————————————————————————
        public static List<Usuarios> GetPrestamos()
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Usuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}