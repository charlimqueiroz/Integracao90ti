using Integracao90ti.Dominio;

namespace Integracao90ti.Dominio
{
    public class ItemPlanilha
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual Planilha Planilha { get; set; }
        public virtual Composicao Composicao { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }

        #endregion

        #region Construtor
        public ItemPlanilha()
        {
        }



        #endregion


    }
}
