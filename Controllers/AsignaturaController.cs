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
    public class AsignaturaController
    {
        public static bool Guardar(Asignaturas entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.Asignaturas.Any(A => A.AsignaturaId == entity.AsignaturaId))
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

        private static bool Insertar(Asignaturas entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Asignaturas.Add(entity);
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

        private static bool Modificar(Asignaturas entity)
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
                Asignaturas asignatura = db.Asignaturas.Find(Id);
                if (asignatura != null)
                {
                    db.Entry(asignatura).State = EntityState.Deleted;
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

        public static Asignaturas Buscar(int Id)
        {
            Contexto db = new Contexto();
            Asignaturas asignatura;

            try
            {
                asignatura = db.Asignaturas.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return asignatura;
        }

        public static List<Asignaturas> GetList(Expression<Func<Asignaturas, bool>> expression)
        {
            List<Asignaturas> lista = new List<Asignaturas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Asignaturas.Where(expression).ToList();

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
