namespace Integracao90ti.Dominio.IRepositorio.Generico
{
    public interface ITransacao
    {
        void Flush();
        void Begin();
        void Commit();
        void Rollback();
    }
}
