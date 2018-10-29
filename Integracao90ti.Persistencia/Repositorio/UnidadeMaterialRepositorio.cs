using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Noventa.Persistencia.Repositorio
{
    public class UnidadeMaterialRepositorio : RepositorioGenerico<UnidadeMaterial>, IUnidadeMaterialRepositorio
    {
        public UnidadeMaterial BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<UnidadeMaterial>().Where(i => i.Descricao == codigo).FirstOrDefault();
        }
    }
}
