using System;

namespace Integracao90ti.Persistencia.ConfiguracaoServidor
{
    [Serializable]
    public class TemplateConfiguracao
    {
        public TemplateConfiguracao()
        {
            Repositorio = new ConfiguracaoRepositorio();
            SessaoUsuario = new SessaoUsuario();
        }

        public ConfiguracaoRepositorio Repositorio { get; set; }
        public SessaoUsuario SessaoUsuario { get; set; }
        public bool AuditoriaEstadoEnable { get; set; }
    }
    
    [Serializable]
    public class ConfiguracaoRepositorio : ConfiguracaoBaseRepositorio
    {
        public ConfiguracaoRepositorio() 
        {
            Dialect = MSSQL2005;
        }

        private const string MYSQL = "MYSQL";
        private const string MSSQL2005 = "MSSQL2005";
        //private const int TimeOut = 8000;
        public string Dialect { get; set; }
        
        [NonSerialized]
        public readonly int MinPoolSize = 1;
        [NonSerialized]
        public readonly int MaxPoolSize = 100;
        [NonSerialized]
        public readonly int ConnectionLifetime = 10;

        public override string GetConnectionString()
        {
            if (Dialect.ToUpper().Contains(MYSQL))
                return GetMySQLConnectionString();
            else //if (Dialect.ToUpper().Contains(MSSQL2005))
                return GetMsSQLConnectionString();
        }

        private string GetMySQLConnectionString()
        {
            return String.Format("Server={0};database={1};user id={2}; pwd={3};Min Pool Size={4};Max Pool Size={5};Connection Lifetime={6}", Server, Database, User, PWD, MinPoolSize, MaxPoolSize, ConnectionLifetime);
        }

        private string GetMsSQLConnectionString()
        {
            return String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2}; Password={3};Min Pool Size={4};Max Pool Size={5};Connection Lifetime={6}", Server, Database, User, PWD, MinPoolSize, MaxPoolSize, ConnectionLifetime);
            //return String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2}; Password={3};Min Pool Size={4};Max Pool Size={5};Connection Lifetime={6};Connection Timeout={7}", Server, Database, User, PWD, MinPoolSize, MaxPoolSize, ConnectionLifetime, TimeOut);
        }
    }

    [Serializable]
    public class SessaoUsuario
    {
        public int TempoInatividade { get; set; }
    }
}
