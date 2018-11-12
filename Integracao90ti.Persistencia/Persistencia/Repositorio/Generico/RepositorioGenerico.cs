using NHibernate;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using Integracao90ti.Dominio.IRepositorio.Generico;
using NHibernate.Context;

namespace Integracao90ti.Persistencia.Repositorio.Generico
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        public RepositorioGenerico()
        {

        }

        public void ReiniciarConexao()
        {
            NHibernateHelper.GetSession().Close();
        }

        #region Implementation of IRepository<T>

        public T BuscarPorId(long id)
        {
            return NHibernateHelper.GetSession().Get<T>(id);
        }

        public IList<T> BuscarTodos()
        {
            return NHibernateHelper.GetSession().Query<T>().ToList(); ;
        }

        public IQueryable<T> Todos()
        {
            return NHibernateHelper.GetSession().Query<T>();
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
            NHibernateHelper.BeginTransaction();
            NHibernateHelper.GetSession().SaveOrUpdate(entity);
            NHibernateHelper.CommitTransaction();
        }

        #endregion

        #region Save
        public void Save(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível salvar uma entidade nula");

            NHibernateHelper.BeginTransaction();
            NHibernateHelper.GetSession().Save(entity);
            NHibernateHelper.CommitTransaction();
        }

        public void SaveAndFlush(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível salvar uma entidade nula");

            NHibernateHelper.BeginTransaction();
            NHibernateHelper.GetSession().Save(entity);
            NHibernateHelper.CommitTransaction();
            NHibernateHelper.GetSession().Flush();
        }

        #endregion

        #region Delete
        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível excluir uma entidade nula");

            NHibernateHelper.BeginTransaction();
            NHibernateHelper.GetSession().Delete(entity);
            NHibernateHelper.CommitTransaction();
        }

        public void DeleteAndFlush(T entity)
        {
            NHibernateHelper.BeginTransaction();
            NHibernateHelper.GetSession().Delete(entity);
            NHibernateHelper.CommitTransaction();
            NHibernateHelper.GetSession().Flush();
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

            NHibernateHelper.BeginTransaction();
            NHibernateHelper.GetSession().Update(entity);
            NHibernateHelper.CommitTransaction();
        }

        public void UpdateAndFlush(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Não é possível atualizar uma entidade nula");

            NHibernateHelper.BeginTransaction();
            NHibernateHelper.GetSession().Update(entity);
            NHibernateHelper.CommitTransaction();
            NHibernateHelper.GetSession().Flush();
        }
        #endregion

        #endregion
    }
}
