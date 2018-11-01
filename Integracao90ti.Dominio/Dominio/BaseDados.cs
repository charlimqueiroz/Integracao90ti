namespace Integracao90ti.Dominio
{
    public class BaseDados
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Nome { get; set; }

        #endregion

        #region Construtor
        public BaseDados()
        {
        }



        #endregion


    }
}
