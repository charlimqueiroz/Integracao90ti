using Integracao90ti.Dominio.IRepositorio.Generico;
using System.Collections.Generic;

namespace Integracao90ti.Dominio.IRepositorio
{
    public interface IProjetoRepositorio : IRepositorioGenerico<Projeto>
    {
        Projeto BuscarPorCodigo(string codigo);
        Projeto BuscarPorNome(string nome);
        IList<Projeto> BuscarPorIdBaseDados(long idBaseDados);
    }
}
