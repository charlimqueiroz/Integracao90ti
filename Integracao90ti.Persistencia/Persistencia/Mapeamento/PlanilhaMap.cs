using FluentNHibernate.Mapping;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Mapeamento
{
    public class PlanilhaMap : ClassMap<Planilha>
    {
        public PlanilhaMap()
        {
            Id(x => x.Id);
            References(x => x.Projeto).Column("Projeto_Id");
            Map(x => x.Codigo).Length(20).Unique().Not.Nullable();
            Map(x => x.Nome).Length(100).Not.Nullable();

            Table("planilha");
        }
    }
}
