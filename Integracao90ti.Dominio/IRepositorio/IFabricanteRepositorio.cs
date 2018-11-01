using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IFabricanteRepositorio : IRepositorioGenerico<Fabricante>
    {
        Fabricante BuscarPorCodigo(string codigo);
        Fabricante BuscarPorDescricao(string descricao);
    }
}
