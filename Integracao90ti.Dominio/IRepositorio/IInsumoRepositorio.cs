using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IInsumoRepositorio : IRepositorioGenerico<Insumo>
    {
        Insumo BuscarPorCodigo(string codigo);
        Insumo BuscarPorDescricao(string descricao);
    }
}
