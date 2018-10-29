using FluentNHibernate.Mapping;
using Noventa.Dominio.Dominio;
using Noventa.Comum;

namespace Integracao90ti.Persistencia.Mapeamento
{
    public class InsumoMap : ClassMap<Insumo>
    {
        public InsumoMap()
        {
            Id(x => x.Id);
            Map(x => x.Empresa_Id).Nullable();
            Map(x => x.UnidadeMaterial_Id).Not.Nullable();
            Map(x => x.Codigo).Length(10).Unique().Not.Nullable();
            Map(x => x.Descricao).Length(30).Not.Nullable();
            Map(x => x.Tipo).Not.Nullable();
            Map(x => x.TipoInsumo).Formula("ascii(tipo)").CustomType<TipoInsumo>().Not.Nullable();
            Map(x => x.ControlaQuantidadeOrcada).Formula("case when ControlaQtdOrc = 'S' then 1 else 0 end").Not.Nullable();
            Map(x => x.ControlaPrecoOrcado).Formula("case when ControlaPcoOrc = 'S' then 1 else 0 end").Not.Nullable();
            Map(x => x.ControlaValorOrcado).Formula("case when ControlaVlrOrc = 'S' then 1 else 0 end").Not.Nullable();
            Map(x => x.Inativo).Not.Nullable();

            References(x => x.Unidade).Column("UnidadeMaterial_Id");

            Table("Insumo");

    }
}
}
