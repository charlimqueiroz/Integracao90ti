using NHibernate;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using Integracao90ti.Dominio.IRepositorio.Generico;

namespace Integracao90ti.Persistencia.Repositorio.Generico
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly ISession _session;

        public RepositorioGenerico()
        {
            NHibernateHelper NHHelper = new NHibernateHelper();
            _session = NHHelper.SessionFactory.OpenSession();
        }

        public ISession GetSessao()
        {
            return _session;
        }

        #region Implementation of IRepository<T>

        public T BuscarPorId(long id)
        {
            return _session.Get<T>(id);
        }

        public IList<T> BuscarTodos()
        {
            return _session.Query<T>().ToList(); ;
        }       

        public IQueryable<T> Todos()
        {
            return _session.Query<T>();
        }

        public T BuscarPor(Expression<Func<T, bool>> expression)
        {
            return FiltrarPor(expression).SingleOrDefault();
        }

        public IQueryable<T> FiltrarPor(Expression<Func<T, bool>> expression)
        {
            return Todos().Where(expression).AsQueryable();
        }

        #endregion
    }
}
