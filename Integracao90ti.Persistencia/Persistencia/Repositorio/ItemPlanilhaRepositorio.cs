using System.Linq;
using Integracao90ti.Dominio.IRepositorio;
using Integracao90ti.Persistencia.Repositorio.Generico;
using System.Collections.Generic;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Repositorio
{
    public class ItemPlanilhaRepositorio : RepositorioGenerico<ItemPlanilha>, IItemPlanilhaRepositorio
    {
        public ItemPlanilha BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<ItemPlanilha>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public ItemPlanilha BuscarPorNome(string nome)
        {
            return GetSessao().Query<ItemPlanilha>().Where(i => i.Nome == nome).FirstOrDefault();
        }

        public IList<ItemPlanilha> BuscarPorIdPlanilha(long idPlanilha)
        {
            return GetSessao().Query<ItemPlanilha>().Where(i => i.Planilha.Id == idPlanilha).ToList();
        }

        public IList<ItemPlanilha> BuscarPorIdPlanilhaEComposicao(long idComposicao, long idPlanilha)
        {
            return GetSessao().Query<ItemPlanilha>().Where(i => i.Planilha.Id == idPlanilha && i.Composicao.Id == idComposicao).ToList();
        }

        public IList<ItemPlanilha> BuscarPorIdComposicao(long idComposicao)
        {
            return GetSessao().Query<ItemPlanilha>().Where(i => i.Composicao.Id == idComposicao).ToList();
        }
    }
}
