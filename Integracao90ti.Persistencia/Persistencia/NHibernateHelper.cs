using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Integracao90ti.Persistencia.Mapeamento;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Integracao90ti.Persistencia
{
    public class NHibernateHelper
    {
        private ConfiguracaoServidor.ConfiguracaoServidor configuracaoServidor = new ConfiguracaoServidor.ConfiguracaoServidor();
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public NHibernateHelper()
        {
            _connectionString = configuracaoServidor.GetConfiguracao().Repositorio.GetConnectionString();
        }

        private ISessionFactory CreateSessionFactory()
        {

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005
                  .ConnectionString(configuracaoServidor.GetConfiguracao().Repositorio.GetConnectionString())
                              .ShowSql()
                )
               .Mappings(m => m.FluentMappings
                              //.AddFromAssemblyOf<Usuario>()
                              .AddFromAssemblyOf<BaseDadosMap>())

               .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory;
        }
    }


}
