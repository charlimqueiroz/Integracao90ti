using Noventa.Dominio.Dominio;
using Noventa.Dominio.IRepositorio.Generico;

namespace Noventa.Dominio.IRepositorio
{
    public interface ISegmentoRepositorio : IRepositorioGenerico<Segmento>
    {
        Segmento BuscarPorCodigo(string codigo);
        Segmento BuscarPorDescricao(string descricao);
    }
}
