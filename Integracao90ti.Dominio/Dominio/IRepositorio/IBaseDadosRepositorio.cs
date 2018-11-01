using Integracao90ti.Dominio.IRepositorio.Generico;

namespace Integracao90ti.Dominio.IRepositorio
{
    public interface IBaseDadosRepositorio : IRepositorioGenerico<BaseDados>
    {
        BaseDados BuscarPorCodigo(string codigo);
        BaseDados BuscarPorNome(string nome);
    }
}
