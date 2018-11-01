﻿using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IUnidadeMaterialRepositorio : IRepositorioGenerico<UnidadeMaterial>
    {
        UnidadeMaterial BuscarPorCodigo(string codigo);
    }
}