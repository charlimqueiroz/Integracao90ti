using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IProcessoCompraRepositorio : IRepositorioGenerico<ProcessoCompra>
    {
        ProcessoCompra BuscarPorNumero(long numero);       
    }
}
