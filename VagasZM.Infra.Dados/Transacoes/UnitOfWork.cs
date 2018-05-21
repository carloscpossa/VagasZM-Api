using VagasZM.Infra.Dados.Contexto;

namespace VagasZM.Infra.Dados.Transacoes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VagasZMDataContext _vagasZMContext;

        public UnitOfWork(VagasZMDataContext vagasZMContext)
        {
            _vagasZMContext = vagasZMContext;
        }

        public void Commit()
        {
            _vagasZMContext.SaveChanges();
        }

        public void Rollback()
        {
            //
        }
    }
}
