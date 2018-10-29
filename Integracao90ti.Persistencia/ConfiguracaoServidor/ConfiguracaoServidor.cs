namespace NIntegracao90ti.Persistencia.ConfiguracaoServidor
{
    public class ConfiguracaoServidor : ConfiguracaoBaseServidor<TemplateConfiguracao>
    {
        public ConfiguracaoServidor()
        {
            FileName = @"serverBD.cfg.xml";
        }
    }
}
