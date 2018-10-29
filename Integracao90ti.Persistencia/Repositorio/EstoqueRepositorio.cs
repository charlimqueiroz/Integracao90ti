using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Noventa.Persistencia.Repositorio
{
    public class EstoqueRepositorio : RepositorioGenerico<Estoque>, IEstoqueRepositorio
    {
        public Estoque BuscarPorCodigo(string codigoMaterial, string codigoLocal)
        {
            return GetSessao().Query<Estoque>().Where(i => i.CodigoMaterial == codigoMaterial && i.CodigoLocal == codigoLocal).FirstOrDefault();
        }
        
    }
}
