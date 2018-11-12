using System.Linq;
using Integracao90ti.Dominio.IRepositorio;
using Integracao90ti.Persistencia.Repositorio.Generico;
using System.Collections.Generic;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Repositorio
{
    public class PlanilhaRepositorio : RepositorioGenerico<Planilha>, IPlanilhaRepositorio
    {
        public Planilha BuscarPorCodigo(string codigo)
        {
            return NHibernateHelper.GetSession().Query<Planilha>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public Planilha BuscarPorNome(string nome)
        {
            return NHibernateHelper.GetSession().Query<Planilha>().Where(i => i.Nome == nome).FirstOrDefault();
        }

        public IList<Planilha> BuscarPorIdProjeto(long idProjeto)
        {
            return NHibernateHelper.GetSession().Query<Planilha>().Where(i => i.Projeto.Id == idProjeto).ToList();
        }
    }
}
