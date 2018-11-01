using System;
using System.IO;
using System.Xml.Serialization;

namespace Integracao90ti.Persistencia.ConfiguracaoServidor
{
    public class ConfiguracaoBaseServidor<T> where T : new()
    {   
        private T config;
        private readonly string PathConfiguracao = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        protected string FileName = "";

        public T GetConfiguracao()
        {
            if (config != null)
                return config;

            if (!File.Exists(System.IO.Path.Combine(PathConfiguracao, FileName)))
                return new T();
                //throw new Exception(String.Format("Arquivo de configuração {0} não encontrado na pasta {1}", FileName, AppDomain.CurrentDomain.BaseDirectory));
            
            XmlSerializer serializer = new XmlSerializer(typeof(T), "");

            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Path.Combine(PathConfiguracao, FileName)))
                {
                    config = (T)serializer.Deserialize(sr);                
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível ler os dados de configuração do arquivo " + FileName, ex);
            }

            return config;
        }

        public void Salvar()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), "");

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Path.Combine(PathConfiguracao, FileName)))
            {
                if (config == null)
                {
                    config = new T();
                }

                serializer.Serialize(sw, config);
            }

        }
    }
}
