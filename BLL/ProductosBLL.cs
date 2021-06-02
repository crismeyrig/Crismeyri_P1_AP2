using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Crismeyri_P1_AP2.DAL;
using Crismeyri_P1_AP2.Models;



namespace Crismeyri_P1_AP2.BLL
{
    public class ProductosBLL
    {
        public static bool Existe(int id) // determina si existe un producto
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Productos.Any(P => P.ProductoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }
        public static bool Insertar ( Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Productos.Add(productos);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar (Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(productos).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductoId))
                return Insertar(productos);
            else
                return Modificar(productos);
        }

        public static bool Eliminar (int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            
            try
            {
                var producto = db.Productos.Find(id);

                if (producto != null)
                {
                    db.Productos.Remove(producto); //remueve la entidad
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;

        }
        public static Productos Buscar(int id)
        {
            Contexto db = new Contexto();
            Productos productos;

            try
            {
                productos = db.Productos.Find(id);
            }
            catch  (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return productos;
        }
        public static List<Productos> GetPersonas()
        {
            List<Productos> lista = new List<Productos>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Productos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {

            List<Productos> lista = new List<Productos>();
            Contexto db = new Contexto(); 
            try
            {
                lista = db.Productos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
            
        }
    }
}
