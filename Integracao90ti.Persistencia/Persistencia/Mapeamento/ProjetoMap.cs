using FluentNHibernate.Mapping;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Mapeamento
{
    public class ProjetoMap : ClassMap<Projeto>
    {
        public ProjetoMap()
        {
            Id(x => x.Id);
            References(x => x.BaseDados).Column("BaseDeDados_Id");
            Map(x => x.Codigo).Length(20).Unique().Not.Nullable();
            Map(x => x.Nome).Length(100).Not.Nullable();

            Table("projeto");
        }
    }
}
