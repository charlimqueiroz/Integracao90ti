using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Integracao90ti.Persistencia.Repositorio
{
    public class InsumoRepositorio : RepositorioGenerico<Insumo>, IInsumoRepositorio
    {
        public Insumo BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<Insumo>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public Insumo BuscarPorDescricao(string descricao)
        {
            return GetSessao().Query<Insumo>().Where(i => i.Descricao == descricao).FirstOrDefault();
        }
    }
}
