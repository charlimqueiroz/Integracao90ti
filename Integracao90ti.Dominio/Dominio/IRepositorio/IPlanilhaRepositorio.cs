using Integracao90ti.Dominio.IRepositorio.Generico;
using System.Collections.Generic;

namespace Integracao90ti.Dominio.IRepositorio
{
    public interface IPlanilhaRepositorio : IRepositorioGenerico<Planilha>
    {
        Planilha BuscarPorCodigo(string codigo);
        Planilha BuscarPorNome(string nome);
        IList<Planilha> BuscarPorIdProjeto(long idProjeto);
    }
}
