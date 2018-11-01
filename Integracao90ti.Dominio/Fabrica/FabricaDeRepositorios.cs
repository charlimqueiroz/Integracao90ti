using System;

namespace Noventa.Dominio.Fabrica
{
    public class FabricaDeRepositorios<T> where T : class
    {
        private static T instancia;

        public static T Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = Construir();

                return instancia;
            }
        }

        private static T Construir()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("Noventa.Persistencia");
           
            //var assembly = System.Reflection.Assembly.Load(ns);
            string ns = "Noventa.Persistencia.Repositorio";
            string classe = ns + "." + typeof(T).Name.Substring(1, typeof(T).Name.Length - 1);

            Type tipo = assembly.GetType(classe, true, true);

            if (typeof(T).GetGenericArguments().Length > 0)
            {
                Type concreteType = tipo.MakeGenericType(typeof(T).GetGenericArguments());
                return (T)Activator.CreateInstance(concreteType);
            }
            else
            {
                System.Reflection.ConstructorInfo ci = tipo.GetConstructor(new Type[] { });
                return (T)ci.Invoke(null);
            }
        }
    }
}
