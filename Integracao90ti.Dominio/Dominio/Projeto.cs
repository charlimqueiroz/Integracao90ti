
namespace Integracao90ti.Dominio
{
    public class Projeto
    {
        #region Atributos da Classe

        public virtual long Id { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Nome { get; set; }
        public virtual BaseDados BaseDados { get; set; }

        #endregion

        #region Construtor
        public Projeto()
        {
        }



        #endregion


    }
}
