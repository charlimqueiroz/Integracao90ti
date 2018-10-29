using System;

namespace Noventa.Testes.Configuracao
{
    [Serializable]
    public class TemplateConfiguracao : BaseConfiguracaoServidorWeb
    {
        public TemplateConfiguracao()
        {
            
            Url = "localhost";
            Porta = 80;
        }
        public override string GetUrlServidor()
        {
            return "http://" + Url + ":" + Porta.ToString() + "/";
        }
    }
    
}
