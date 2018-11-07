namespace Integracao90ti.Dominio
{
    public class Composicao
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string CodigoAuxiliar { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Unidade { get; set; }
        public virtual decimal PrecoServico { get; set; }
        public virtual decimal ValorTotalCusto { get; set; }

        #endregion

        #region Construtor
        public Composicao()
        {
        }



        #endregion

        #region Propriedades Publicas

        public virtual string DescricaoVisualizacao()
        {
            if (string.IsNullOrEmpty(Descricao))
                return Nome;
            else
                return Descricao;
        }

        public virtual string CodigoComposicao()
        {
            if (string.IsNullOrEmpty(CodigoAuxiliar))
                return Codigo;
            else
                return CodigoAuxiliar;
        }

        #endregion
    }
}
