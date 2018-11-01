using Integracao90ti.Dominio.IRepositorio.Generico;
using System;

namespace Integracao90ti.Dominio.Fabrica
{
    public class ActivatorTransacao
    {
        private static ITransacao instancia;

        public static ITransacao Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = Construir("Transacao");
                }
                return instancia;
            }
        }

        static ITransacao Construir(string className)
        {
            string ns = "Integracao90ti.Dominio";
            var assembly = System.Reflection.Assembly.Load(ns);

            string classe = ns + "." + typeof(ITransacao).Name.Substring(1, typeof(ITransacao).Name.Length - 1);

            Type tipo = assembly.GetType(classe, true, true);

            if (typeof(ITransacao).GetGenericArguments().Length > 0)
            {
                Type concreteType = tipo.MakeGenericType(typeof(ITransacao).GetGenericArguments());
                return (ITransacao)Activator.CreateInstance(concreteType);
            }
            else
            {
                System.Reflection.ConstructorInfo ci = tipo.GetConstructor(new Type[] { });
                return (ITransacao)ci.Invoke(null);
            }
        }
    }
}
