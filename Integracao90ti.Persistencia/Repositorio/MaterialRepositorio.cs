using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Noventa.Persistencia.Repositorio
{
    public class MaterialRepositorio : RepositorioGenerico<Material>, IMaterialRepositorio
    {
        public Material BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<Material>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public Material BuscarPorDescricao(string descricao)
        {
            return GetSessao().Query<Material>().Where(i => i.Descricao == descricao).FirstOrDefault();
        }
    }
}
