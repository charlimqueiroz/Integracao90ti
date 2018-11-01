using FluentNHibernate.Mapping;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Mapeamento
{
    public class BaseDadosMap : ClassMap<BaseDados>
    {
        public BaseDadosMap()
        {
            Id(x => x.Id);
            Map(x => x.Codigo).Length(20).Unique().Not.Nullable();
            Map(x => x.Nome).Length(100).Not.Nullable();

            Table("base_de_dados");

    }
}
}
