using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IItemProcessoCompraRepositorio : IRepositorioGenerico<ItemProcessoCompra>
    {
        ItemProcessoCompra BuscarPorSequencia(int sequencia);       
    }
}
