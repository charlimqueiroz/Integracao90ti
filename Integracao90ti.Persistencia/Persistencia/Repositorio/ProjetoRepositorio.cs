using System.Linq;
using Integracao90ti.Dominio.IRepositorio;
using Integracao90ti.Persistencia.Repositorio.Generico;
using System.Collections.Generic;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Repositorio
{
    public class ProjetoRepositorio : RepositorioGenerico<Projeto>, IProjetoRepositorio
    {
        public Projeto BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<Projeto>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public Projeto BuscarPorNome(string nome)
        {
            return GetSessao().Query<Projeto>().Where(i => i.Nome == nome).FirstOrDefault();
        }

        public IList<Projeto> BuscarPorIdBaseDados(long idBaseDados)
        {
            return GetSessao().Query<Projeto>().Where(i => i.BaseDados.Id == idBaseDados).ToList();
        }
    }
}
