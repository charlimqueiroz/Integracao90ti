namespace Integracao90ti.Persistencia.ConfiguracaoServidor
{
    public class ConfiguracaoServidor : ConfiguracaoBaseServidor<TemplateConfiguracao>
    {
        public ConfiguracaoServidor()
        {
            FileName = @"server.cfg.xml";
        }
    }
}
