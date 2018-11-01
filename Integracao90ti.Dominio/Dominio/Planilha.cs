using Integracao90ti.Dominio;

namespace Integracao90ti.Dominio
{
    public class Planilha
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Nome { get; set; }

        #endregion

        #region Construtor
        public Planilha()
        {
        }



        #endregion


    }
}
