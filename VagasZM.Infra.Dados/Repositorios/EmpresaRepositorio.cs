using System;
using System.Linq;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Contexto;

namespace VagasZM.Infra.Dados.Repositorios
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly VagasZMDataContext _contexto;
        public EmpresaRepositorio(VagasZMDataContext contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Empresa empresa)
        {
            _contexto.Empresa.Add(empresa);
        }

        public Empresa BuscaEmpresaPorId(Guid Id)
        {
            return _contexto
                        .Empresa
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Id == Id);
        }
    }
}
