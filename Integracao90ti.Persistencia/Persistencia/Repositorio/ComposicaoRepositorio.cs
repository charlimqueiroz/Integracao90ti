using System.Linq;
using Integracao90ti.Dominio.IRepositorio;
using Integracao90ti.Persistencia.Repositorio.Generico;
using System.Collections.Generic;
using Integracao90ti.Dominio;

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
    }
}
