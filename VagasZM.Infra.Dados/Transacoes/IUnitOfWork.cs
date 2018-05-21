namespace VagasZM.Infra.Dados.Transacoes
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
