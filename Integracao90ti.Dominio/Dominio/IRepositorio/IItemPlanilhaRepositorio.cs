using Integracao90ti.Dominio.IRepositorio.Generico;
using System.Collections.Generic;

namespace Integracao90ti.Dominio.IRepositorio
{
    public interface IItemPlanilhaRepositorio : IRepositorioGenerico<ItemPlanilha>
    {
        ItemPlanilha BuscarPorCodigo(string codigo);
        ItemPlanilha BuscarPorNome(string nome);
        IList<ItemPlanilha> BuscarPorIdPlanilha(long idPlanilha);
        IList<ItemPlanilha> BuscarPorIdPlanilhaEComposicao(long idComposicao, long idPlanilha);
        IList<ItemPlanilha> BuscarPorIdComposicao(long idComposicao);
    }
}
