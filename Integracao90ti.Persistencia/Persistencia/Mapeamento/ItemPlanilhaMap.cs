using FluentNHibernate.Mapping;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Mapeamento
{
    public class ItemPlanilhaMap : ClassMap<ItemPlanilha>
    {
        public ItemPlanilhaMap()
        {
            Id(x => x.Id);
            References(x => x.Planilha).Column("Planilha_Id");
            References(x => x.Composicao).Column("Composicao_Id");
            Map(x => x.Codigo).Length(100).Unique().Not.Nullable();
            Map(x => x.Nome).Length(100).Not.Nullable();
            Map(x => x.Descricao).Length(1000).Not.Nullable();
            Map(x => x.Quantidade).Not.Nullable();
            
            Table("item_planilha");
        }
    }
}
