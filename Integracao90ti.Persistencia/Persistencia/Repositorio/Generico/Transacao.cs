using Integracao90ti.Dominio.IRepositorio.Generico;
using Noventa.Compor90.Hibernate.Util;

namespace Noventa.Compor90.Repositorio
{
    /// <summary>
    /// Transaction
    /// </summary>
    public class Transacao : ITransacao
    {
        public static Transacao Create()
        {
            return new Transacao();
        }

        public void Flush()
        {
            HibernateLoaderSessionManager.Instance.GetSessionFrom(new EventInterceptor()).Flush();
        }

        /// <summary>
        /// Iniciar transação
        /// </summary>
        public void Begin()
        {
            HibernateLoaderSessionManager.Instance.BeginTransactionOn(new EventInterceptor());
        }

        /// <summary>
        /// Confirmar transação
        /// </summary>
        public void Commit()
        {
            HibernateLoaderSessionManager.Instance.CommitTransactionOn();
        }

        /// <summary>
        /// Cancelar transação
        /// </summary>
        public void Rollback()
        {
            HibernateLoaderSessionManager.Instance.RollbackTransactionOn();
        }
    }
}
