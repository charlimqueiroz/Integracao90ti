namespace Integracao90ti.Dominio
{
    public class Composicao
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Unidade { get; set; }
        public virtual decimal PrecoServico { get; set; }

        #endregion

        #region Construtor
        public Composicao()
        {
        }



        #endregion


    }
}
