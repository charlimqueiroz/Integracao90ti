using NHibernate;
using NHibernate.Cache;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Exceptions;
using NHibernate.Tool.hbm2ddl;
using Noventa.Compor90.Comum.Configuracao;
using Noventa.Compor90.Util;
using Noventa.Compor90.Util.Auth;
using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using System.Web.Caching;
using Environment = NHibernate.Cfg.Environment;

namespace Noventa.Compor90.Hibernate.Util
{
    // <summary>
    /// Handles creation and management of sessions and transactions.
    /// It is a singleton because building
    /// the initial session factory is very expensive.
    /// Inspiration for this class came from Chapter 8 of Hibernate in Action
    /// by Bauer and King. Although it is a sealed singleton you can use TypeMock
    /// (http://www.typemock.com) for more flexible testing.
    /// </summary>

    public sealed class HibernateLoaderSessionManager
    {
        #region Thread-safe, lazy Singleton

        /// <summary>
        /// This is a thread-safe, lazy singleton.
        /// See http://www.yoda.arachsys.com/csharp/singleton.html
        /// for more details about its implementation.
        /// </summary>

        public static HibernateLoaderSessionManager Instance
        {
            get
            {
                return Nested.HibernateLoaderSessionManager;
            }
        }
        public static string DiretorioConfiguracao { get; set; }

        public static Configuration Configuration { get; set; }

        /// <summary>
        /// Private constructor to enforce singleton
        /// </summary>

        private HibernateLoaderSessionManager() { }

        private string _sessionFactoryDatabase = ConfiguracaoServidor.GetConfiguracao(null).Repositorio.XmlDatabaseCliente;

        public string SessionFactoryDatabase
        {
            get
            {
                var currentThread = Thread.CurrentThread;
                string threadDatabase = AsyncUtil.ObterThreadDataBase(currentThread);
                if (!string.IsNullOrEmpty(threadDatabase))
                {
                    return threadDatabase;
                }

                if (HttpContext.Current != null)
                {
                    var user = HttpContext.Current.User as IPrincipal90;
                    if (user != null)
                        return user.DataBaseName;
                }
                
                return _sessionFactoryDatabase;
            }

            set
            {
                _sessionFactoryDatabase = value;

                TemplateConfiguracao config = ConfiguracaoServidor.GetConfiguracao(DiretorioConfiguracao);
                config.Repositorio.CurrentDatabase = _sessionFactoryDatabase;

                if (HttpContext.Current != null)
                {
                    var user = HttpContext.Current.User as IPrincipal90;
                    if (user != null)
                        user.DataBaseName = value;
                }
            }
        }

        /// <summary>
        /// Assists with ensuring thread-safe, lazy singleton
        /// </summary>

        private class Nested
        {
            static Nested() { }
            internal static readonly HibernateLoaderSessionManager
               HibernateLoaderSessionManager = new HibernateLoaderSessionManager();
        }

        #endregion

        /// <summary>
        /// This method attempts to find a session factory
        /// in the <see cref="HttpRuntime.Cache" /> 
        /// via its config file path; if it can't be
        /// found it creates a new session factory and adds
        /// it the cache. Note that even though this uses HttpRuntime.Cache,
        /// it should still work in Windows applications; see
        /// http://www.codeproject.com/csharp/cacheinwinformapps.asp
        /// for an examination of this.
        /// </summary>

        private ISessionFactory GetSessionFactoryFor()
        {
            if (string.IsNullOrEmpty(SessionFactoryDatabase))
                throw new ArgumentNullException("sessionFactoryConfigPath" +
                          " may not be null nor empty");

            //  Attempt to retrieve a cached SessionFactory from the HttpRuntime's cache.
            ISessionFactory sessionFactory =
              (ISessionFactory)HttpRuntime.Cache.Get(SessionFactoryDatabase);

            //  Failed to find a cached SessionFactory so make a new one.
            if (sessionFactory == null)
            {
                //  Now that we have our Configuration object, create a new SessionFactory
                sessionFactory = BuildSessionFactory();

                if (sessionFactory == null)
                {
                    throw new InvalidOperationException(
                      "cfg.BuildSessionFactory() returned null.");
                }

                HttpRuntime.Cache.Add(SessionFactoryDatabase,
                            sessionFactory, null, DateTime.Now.AddDays(7),
                    TimeSpan.Zero, CacheItemPriority.High, null);
            }
            
            return sessionFactory;
        }

        public ISessionFactory BuildSessionFactory()
        {
            TemplateConfiguracao config = ConfiguracaoServidor.GetConfiguracao(DiretorioConfiguracao);

            Type dialectType = null;
            Type driverType = null;

            if (config.Repositorio.Dialect.ToLower().Contains("mssql2005"))
            {
                dialectType = typeof(MsSql2005Dialect);
                driverType = typeof(SqlClientDriver);
            }

            config.Repositorio.Database = SessionFactoryDatabase;
            config.Repositorio.CurrentDatabase = SessionFactoryDatabase;

            var cfg = new Configuration()
                    .SetProperty(Environment.Dialect, dialectType.AssemblyQualifiedName)
                    .SetProperty(Environment.ConnectionDriver, driverType.AssemblyQualifiedName)
                    .SetProperty(Environment.ConnectionString, config.Repositorio.GetConnectionString())
                    .SetProperty(Environment.UseSecondLevelCache, "true")
                    .SetProperty(Environment.GenerateStatistics, "true")
                    .SetProperty(Environment.UseQueryCache, "true")
                    .SetProperty(Environment.CacheDefaultExpiration, "100000")
                    .SetProperty(Environment.Hbm2ddlKeyWords, "None")
                    .SetProperty(Environment.SqlExceptionConverter, typeof(ISQLExceptionConverter).AssemblyQualifiedName)
                    .SetProperty(Environment.CommandTimeout, "600")
                    .AddAssembly(typeof(HibernateLoaderSessionManager).Assembly);

#if DEBUG
            cfg.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
            cfg.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
#endif

            Configuration = cfg;

            return cfg.BuildSessionFactory();
        }

        public void RegisterInterceptorOn(IInterceptor interceptor)
        {
            ISession session = (ISession)contextSessions[SessionFactoryDatabase];

            if (session != null && session.IsOpen)
            {
                throw new CacheException("You cannot register " +
                      "an interceptor once a session has already been opened");
            }

            GetSessionFrom(interceptor);
        }

        public ISession GetSessionFrom(IInterceptor interceptor = null)
        {
            ISession session = (ISession)contextSessions[SessionFactoryDatabase];

            if (session == null)
            {
                if (interceptor != null)
                {
                    session = GetSessionFactoryFor().OpenSession(interceptor);
                }
                else
                {
                    session =
                     GetSessionFactoryFor().OpenSession();
                }

                contextSessions[SessionFactoryDatabase] = session;
            }

            if (session == null)
                // It would be more appropriate to throw
                // a more specific exception than ApplicationException

                throw new ApplicationException("session was null");

            return session;
        }

        public void CloseSessionOn()
        {
            ISession session = (ISession)contextSessions[SessionFactoryDatabase];
            contextSessions.Remove(SessionFactoryDatabase);

            if (session != null && session.IsOpen)
            {
                session.Close();
            }

            HttpRuntime.Cache.Remove(SessionFactoryDatabase);
        }

        public void BeginTransactionOn(IInterceptor interceptor = null)
        {
            ITransaction transaction =
              (ITransaction)contextTransactions[SessionFactoryDatabase];

            if (transaction == null)
            {
                transaction = GetSessionFrom(interceptor).BeginTransaction();
                contextTransactions.Add(SessionFactoryDatabase, transaction);
            }
        }

        public void CommitTransactionOn()
        {
            ITransaction transaction =
              (ITransaction)contextTransactions[SessionFactoryDatabase];

            try
            {
                if (transaction != null && !transaction.WasCommitted
                                        && !transaction.WasRolledBack)
                {
                    transaction.Commit();
                    contextTransactions.Remove(SessionFactoryDatabase);
                }
            }
            catch (HibernateException)
            {
                RollbackTransactionOn();
                throw;
            }
        }

        public void RollbackTransactionOn()
        {
            ITransaction transaction =
              (ITransaction)contextTransactions[SessionFactoryDatabase];

            try
            {
                contextTransactions.Remove(SessionFactoryDatabase);

                if (transaction != null && !transaction.WasCommitted
                                        && !transaction.WasRolledBack)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                CloseSessionOn();
            }
        }

        /// <summary>
        /// Since multiple databases may be in use, there may be one transaction per database 
        /// persisted at any one time. The easiest way to store them is via a hashtable
        /// with the key being tied to session factory.
        /// </summary>

        private Hashtable contextTransactions
        {
            get
            {
                if (CallContext.GetData("CONTEXT_TRANSACTIONS") == null)
                {
                    CallContext.SetData("CONTEXT_TRANSACTIONS", new Hashtable());
                }

                return (Hashtable)CallContext.GetData("CONTEXT_TRANSACTIONS");
            }
        }

        /// <summary>
        /// Since multiple databases may be in use, there may be one session per database 
        /// persisted at any one time. The easiest way to store them is via a hashtable
        /// with the key being tied to session factory.
        /// </summary>

        private Hashtable contextSessions
        {
            get
            {
                if (CallContext.GetData("CONTEXT_SESSIONS") == null)
                {
                    CallContext.SetData("CONTEXT_SESSIONS", new Hashtable());
                }

                return (Hashtable)CallContext.GetData("CONTEXT_SESSIONS");
            }
        }
    }
}
