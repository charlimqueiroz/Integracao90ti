using System.Runtime.Remoting.Messaging;
using NHibernate;
using Integracao90ti.Persistencia.Mapeamento;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Integracao90ti.Persistencia
{
    /// <summary>
    /// Gerencia de sessão e transação do nhibernate
    /// </summary>
    public class NHibernateHelper
    {
        //Variáveis de contexto da thread
        private const string HIBERNATE_SESSION = "HIBERNATE_SESSION";
        private const string THREAD_TRANSACTION = "THREAD_TRANSACTION";
        private const string SCOPE_LOGGER = "SCOPE_LOGGER";

        /// <summary>
        /// Define a quantidades de entidades serão enviadas por vez pelo hibernate para insert ou update
        /// Sempre use acompanhado dos métodos Flush() e Clear()
        ///</summary>
        public const int BATCH_SIZE = 100;

        private static ISessionFactory sessionFactory;
        private static ConfiguracaoServidor.ConfiguracaoServidor configuracaoServidor = new ConfiguracaoServidor.ConfiguracaoServidor();

        public static bool AuditoriaEstadoEnabled { get; set; }
        public static bool GravarAuditoria { get; set; }

        //private static int transactionCounter;

        //public static IDictionary<string, object> myCache;
        //public static IList<object> newObjects = new List<object>();
        //public static IList<object> deletedObjects = new List<object>();

        //private TransactionScopeLogger scopeLogger;

        static NHibernateHelper()
        {
            sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005
                  .ConnectionString(configuracaoServidor.GetConfiguracao().Repositorio.GetConnectionString())
                              .ShowSql()
                )
               .Mappings(m => m.FluentMappings
                              //.AddFromAssemblyOf<Usuario>()
                              .AddFromAssemblyOf<BaseDadosMap>())

               .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
               //.ExposeConfiguration(cfg => cfg.SetProperty("current_session_context_class", "thread"))
               .BuildSessionFactory();
        }

        public static IStatelessSession GetStatelessSession()
        {
            return sessionFactory.OpenStatelessSession();
        }

        /// <summary>
        /// Obter a sessão do nhibernate
        /// </summary>
        /// <returns></returns>
        public static ISession GetSession()
        {
            ISession s = (ISession)CallContext.GetData(HIBERNATE_SESSION);
            if (s == null || !s.IsOpen)
            {
                s = sessionFactory.OpenSession();
                s.FlushMode = FlushMode.Commit;
                CallContext.SetData(HIBERNATE_SESSION, s);
            }

            return s;
        }

        /// <summary>
        /// Finalizar sessão do nhibernate
        /// </summary>
        public static void CloseSession()
        {
            ISession s = (ISession)CallContext.GetData(HIBERNATE_SESSION);

            if (s != null && s.IsOpen)
                s.Close();

            CallContext.FreeNamedDataSlot(HIBERNATE_SESSION);
        }

        /// <summary>
        /// Iniciar controle da transação
        /// </summary>
        public static void BeginTransaction()
        {
            ITransaction tx = (ITransaction)CallContext.GetData(THREAD_TRANSACTION);

            if (tx == null)
            {
                tx = GetSession().BeginTransaction();
                CallContext.SetData(THREAD_TRANSACTION, tx);
            }
        }

        /// <summary>
        /// Efetuar commit() da transação.
        /// </summary>
        public static void CommitTransaction(bool flush = false)
        {
            ITransaction tx = (ITransaction)CallContext.GetData(THREAD_TRANSACTION);

            if (!tx.WasCommitted && !tx.WasRolledBack)
            {
                GetSession().Flush();
                tx.Commit();
                CallContext.FreeNamedDataSlot(THREAD_TRANSACTION);
            }

            CloseSession();

        }

        /// <summary>
        /// Efetuar Flush()
        /// </summary>
        public static void Flush()
        {
            GetSession().Flush();
        }

        /// <summary>
        /// Efetuar Rollback() da transação.
        /// </summary>
        public static void RollbackTransaction()
        {
            ITransaction tx = (ITransaction)CallContext.GetData(THREAD_TRANSACTION);

            CallContext.FreeNamedDataSlot(THREAD_TRANSACTION);

            if (tx != null && !tx.WasCommitted && !tx.WasRolledBack)
                tx.Rollback();
        }

        //public static TransactionScopeLogger GetScopeLogger()
        //{
        //    TransactionScopeLogger sl = (TransactionScopeLogger)CallContext.GetData(SCOPE_LOGGER);

        //    if (sl == null)
        //    {
        //        sl = new TransactionScopeLogger();
        //        CallContext.SetData(SCOPE_LOGGER, sl);
        //    }

        //    return sl;
        //}
    }
}
