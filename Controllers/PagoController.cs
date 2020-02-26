using Inscripcion.Data;
using Inscripcion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inscripcion.Controllers
{
    public class PagoController
    {
        public static bool Guardar(Pagos entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.Pagos.Any(A => A.PagoId == entity.PagoId))
                {
                    paso = Modificar(entity);
                }
                else
                {
                    paso = Insertar(entity);
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

        private static bool Insertar(Pagos entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Pagos.Add(entity);
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

        private static bool Modificar(Pagos entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Entry(entity).State = EntityState.Modified;
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

        public static bool Eliminar(int Id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                Pagos pago = db.Pagos.Find(Id);
                if (pago != null)
                {
                    db.Entry(pago).State = EntityState.Deleted;
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

        public static Pagos Buscar(int Id)
        {
            Contexto db = new Contexto();
            Pagos pago;

            try
            {
                pago = db.Pagos.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return pago;
        }

        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
        {
            List<Pagos> lista = new List<Pagos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Pagos.Where(expression).ToList();

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
