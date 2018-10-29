using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Noventa.Persistencia.Repositorio
{
    public class CategoriaRepositorio : RepositorioGenerico<Categoria>, ICategoriaRepositorio
    {
        public Categoria BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<Categoria>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public Categoria BuscarPorDescricao(string descricao)
        {
            return GetSessao().Query<Categoria>().Where(i => i.Descricao == descricao).FirstOrDefault();
        }
    }
}
