﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Integracao90ti.Dominio.IRepositorio.Generico
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T BuscarPorId(long id);
        IList<T> BuscarTodos();
        IQueryable<T> Todos();
        T BuscarPor(Expression<Func<T, bool>> expression);
        IQueryable<T> FiltrarPor(Expression<Func<T, bool>> expression);
        void SaveOrUpdate(T entity);
        void Save(T entity);
        void SaveAndFlush(T entity);
        void Delete(T entity);
        void DeleteAndFlush(T entity);
        void Update(T entity);
        void UpdateAndFlush(T entity);

    }
}