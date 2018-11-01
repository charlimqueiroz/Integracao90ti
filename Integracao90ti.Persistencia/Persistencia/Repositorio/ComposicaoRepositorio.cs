using System.Linq;
using Integracao90ti.Dominio.IRepositorio;
using Integracao90ti.Persistencia.Repositorio.Generico;
using System.Collections.Generic;
using Integracao90ti.Dominio;
using NHibernate;

namespace Integracao90ti.Persistencia.Repositorio
{
    public class ComposicaoRepositorio : RepositorioGenerico<Composicao>, IComposicaoRepositorio
    {
        public Composicao BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<Composicao>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public Composicao BuscarPorNome(string nome)
        {
            return GetSessao().Query<Composicao>().Where(i => i.Nome == nome).FirstOrDefault();
        }

        public IList<Composicao> BuscarPorIdProjeto(long idProjeto)
        {
            return GetSessao().Query<Composicao>().Where(i => i.Projeto.Id == idProjeto).ToList();
        }

        public IList<Composicao> BuscarPorIdPlanilha(long idPlanilha)
        {
            string sql = "select composicao.* " +
                         "from composicao " +
                         "inner join item_planilha on item_planilha.Composicao_Id = composicao.Id " +
                         "inner " +
                         "join planilha on planilha.id = item_planilha.Planilha_Id " +
                         "where planilha.id = " + idPlanilha.ToString();

            IQuery q = GetSessao().CreateSQLQuery(sql).AddEntity(typeof(Composicao));

            return q.List<Composicao>().ToList();
        }
    }
}
