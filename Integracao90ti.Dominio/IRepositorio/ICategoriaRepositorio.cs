using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface ICategoriaRepositorio : IRepositorioGenerico<Categoria>
    {
        Categoria BuscarPorCodigo(string codigo);
        Categoria BuscarPorDescricao(string descricao);
    }
}
