using Integracao90ti.Dominio.IRepositorio.Generico;
using System.Collections.Generic;

namespace Integracao90ti.Dominio.IRepositorio
{
    public interface IComposicaoRepositorio : IRepositorioGenerico<Composicao>
    {
        Composicao BuscarPorCodigo(string codigo);
        Composicao BuscarPorNome(string nome);
        IList<Composicao> BuscarPorIdProjeto(long idProjeto);
    }
}
