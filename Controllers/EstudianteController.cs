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
    public class EstudianteController
    {
        public static bool Guardar(Estudiantes entity)
        {
            Contexto db = new Contexto();
            bool paso = false;
            try
            {
                if (db.Estudiantes.Any(A => A.EstudianteId == entity.EstudianteId))
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

        private static bool Insertar(Estudiantes entity)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Estudiantes.Add(entity);
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

        private static bool Modificar(Estudiantes entity)
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
                Estudiantes estudiante = db.Estudiantes.Find(Id);
                if (estudiante != null)
                {
                    db.Entry(estudiante).State = EntityState.Deleted;
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

        public static Estudiantes Buscar(int Id)
        {
            Contexto db = new Contexto();
            Estudiantes estudiante;

            try
            {
                estudiante = db.Estudiantes.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return estudiante;
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> expression)
        {
            List<Estudiantes> lista = new List<Estudiantes>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Estudiantes.Where(expression).ToList();

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
