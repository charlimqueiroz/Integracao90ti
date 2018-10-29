using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Noventa.Persistencia.Repositorio
{
    public class ItemProcessoCompraRepositorio : RepositorioGenerico<ItemProcessoCompra>, IItemProcessoCompraRepositorio
    {
        public ItemProcessoCompra BuscarPorSequencia(int sequencia)
        {
            return GetSessao().Query<ItemProcessoCompra>().Where(i => i.Sequencia == sequencia).FirstOrDefault();
        }
    }
}
