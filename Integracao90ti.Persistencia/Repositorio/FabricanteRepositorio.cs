using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Noventa.Persistencia.Repositorio
{
    public class FabricanteRepositorio : RepositorioGenerico<Fabricante>, IFabricanteRepositorio
    {
        public Fabricante BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<Fabricante>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public Fabricante BuscarPorDescricao(string descricao)
        {
            return GetSessao().Query<Fabricante>().Where(i => i.Descricao == descricao).FirstOrDefault();
        }
    }
}
