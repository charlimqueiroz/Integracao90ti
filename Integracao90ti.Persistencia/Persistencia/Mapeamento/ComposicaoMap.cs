using FluentNHibernate.Mapping;
using Integracao90ti.Dominio;

namespace Integracao90ti.Persistencia.Mapeamento
{
    public class ComposicaoMap : ClassMap<Composicao>
    {
        public ComposicaoMap()
        {
            Id(x => x.Id);
            References(x => x.Projeto).Column("Projeto_Id");
            Map(x => x.Codigo).Length(20).Unique().Not.Nullable();
            Map(x => x.Nome).Length(100).Not.Nullable();
            Map(x => x.Descricao).Length(1000).Not.Nullable();
            Map(x => x.PrecoServico).Not.Nullable();
            Map(x => x.Unidade).Length(10).Not.Nullable();

            Table("composicao");
        }
    }
}
