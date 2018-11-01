using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IEstoqueRepositorio : IRepositorioGenerico<Estoque>
    {
        Estoque BuscarPorCodigo(string codigoMaterial, string codigoLocal);
        
    }
}
