using System;

namespace Noventa.Testes.Configuracao
{
    [Serializable]
    public abstract class BaseConfiguracaoServidorWeb
    {
        public string Url { get; set; }
        public int Porta { get; set; }
        public abstract string GetUrlServidor();
    }
}
