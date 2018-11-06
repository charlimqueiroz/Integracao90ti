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

        #region SaveOrUpdate
        public void SaveOrUpdate(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SetBatchSize(1000);
                _session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        #endregion

        #region Save
        public void Save(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível salvar uma entidade nula");
            using (var transaction = _session.BeginTransaction())
            {
                _session.SetBatchSize(1000);
                _session.Save(entity);
                transaction.Commit();
            }
        }

        public void SaveAndFlush(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível salvar uma entidade nula");

            using (var transaction = _session.BeginTransaction())
            {
                _session.SetBatchSize(1000);
                _session.Save(entity);
                transaction.Commit();
            }
            _session.Flush();
        }

        #endregion

        #region Delete
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível excluir uma entidade nula");
 
            using (var transaction = _session.BeginTransaction())
            {
                _session.SetBatchSize(1000);
                _session.Delete(entity);
                transaction.Commit();
            }
        }

        public void DeleteAndFlush(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.SetBatchSize(1000);
                _session.Delete(entity);
                transaction.Commit();
            }

            _session.Flush();
        }

        //public void Delete(ID id)
        //{
        //    if (id.Equals(0))
        //        throw new ArgumentOutOfRangeException("Não é possível excluir uma entidade com identificador zero");

        //    persistentClass = BuscarPeloId(id);
        //    Delete(persistentClass);
        //}

        //public void DeleteAndFlush(ID id)
        //{
        //    Delete(id);
        //    _session.Flush();
        //}

        #endregion

        #region Update
        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível atualizar uma entidade nula");

            using (var transaction = _session.BeginTransaction())
            {
                _session.SetBatchSize(1000);
                _session.Update(entity);
                transaction.Commit();
            }
        }

        public void UpdateAndFlush(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível atualizar uma entidade nula");

            using (var transaction = _session.BeginTransaction())
            {
                _session.SetBatchSize(1000);
                _session.Update(entity);
                transaction.Commit();
            }
            _session.Flush();
        }
        #endregion

        #endregion
    }
}
