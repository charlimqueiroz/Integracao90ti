using NHibernate.Linq;
using Noventa.Dominio.IRepositorio;
using System.Linq;
using Noventa.Persistencia.Repositorio.Generico;
using Noventa.Dominio.Dominio;

namespace Noventa.Persistencia.Repositorio
{
    public class SegmentoRepositorio : RepositorioGenerico<Segmento>, ISegmentoRepositorio
    {
        public Segmento BuscarPorCodigo(string codigo)
        {
            return GetSessao().Query<Segmento>().Where(i => i.Codigo == codigo).FirstOrDefault();
        }
        public Segmento BuscarPorDescricao(string descricao)
        {
            return GetSessao().Query<Segmento>().Where(i => i.Descricao == descricao).FirstOrDefault();
        }
    }
}
