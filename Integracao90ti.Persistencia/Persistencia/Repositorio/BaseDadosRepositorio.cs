using System.Linq;
using Integracao90ti.Dominio.IRepositorio;
using Integracao90ti.Persistencia.Repositorio.Generico;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Repositorio
{
    public class BaseDadosRepositorio : RepositorioGenerico<BaseDados>, IBaseDadosRepositorio
    {
        public BaseDados BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<BaseDados>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public BaseDados BuscarPorNome(string nome)
        {
            return GetSessao().Query<BaseDados>().Where(i => i.Nome == nome).FirstOrDefault();
        }
    }
}
