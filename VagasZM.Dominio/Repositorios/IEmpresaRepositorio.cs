using System;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Repositorios
{
    public interface IEmpresaRepositorio
    {
        void Adicionar(Empresa empresa);

        Empresa BuscaEmpresaPorId(Guid Id);
    }
}
