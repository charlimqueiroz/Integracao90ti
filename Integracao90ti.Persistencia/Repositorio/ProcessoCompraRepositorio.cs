using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Noventa.Persistencia.Repositorio
{
    public class ProcessoCompraRepositorio : RepositorioGenerico<ProcessoCompra>, IProcessoCompraRepositorio
    {
        public ProcessoCompra BuscarPorNumero(long numero)
        {
            return GetSessao().Query<ProcessoCompra>().Where(i => i.Numero == numero).FirstOrDefault();
        }
    }
}
