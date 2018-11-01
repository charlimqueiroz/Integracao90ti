using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface IMaterialRepositorio : IRepositorioGenerico<Material>
    {
        Material BuscarPorCodigo(string codigo);
        Material BuscarPorDescricao(string descricao);
    }
}
