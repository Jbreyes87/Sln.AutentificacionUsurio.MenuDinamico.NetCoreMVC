using Dapper;
using Dapper.Contrib.Extensions;
using Emsoir.Infraestructura.Interface;
using Emsoir.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Emsoir.Infraestructura.Repository
{
    public class Repositoy<T> : Irepository<T> where T : class
    {
        private IConectionFactory _ConectionFactory;
        public Repositoy(IConectionFactory ConectionFactory)
        {
            _ConectionFactory = ConectionFactory;
        }

        public IEnumerable<T> GetList()
        {
            //string sql = "SELECT * FROM Categorias";

            using (var conn = _ConectionFactory.GetConection)
            {
                //var invoices = conn.GetAll<T>().ToList();
                //return invoices;
                return conn.GetAll<T>().ToList();
            }
        }
        public T GetById(int id)
        {
            using (var conn = _ConectionFactory.GetConection)
            {
                return conn.Get<T>(id);
            }

        }

        public bool Add(T entity)
        {
            bool respuesta = false;
            try
            {

                using (var conn = _ConectionFactory.GetConection)
                {
                     conn.Insert(entity);

                }

                respuesta = true;
            }
            catch (Exception e)
            {
                var res = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Update(T entity)
        {
            bool respuesta = false;
            try
            {
                using (var conn = _ConectionFactory.GetConection)
                {
                    conn.Update(entity);

                }

                respuesta = true;
            }
            catch (Exception e)
            {
                var res = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Delete(T entity)
        {
            bool respuesta = false;
            try
            {

                using (var conn = _ConectionFactory.GetConection)
                {

                    conn.Delete(entity);

                }

                respuesta = true;
            }
            catch (Exception e)
            {
                var res = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
