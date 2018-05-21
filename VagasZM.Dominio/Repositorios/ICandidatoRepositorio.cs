using System;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Repositorios
{
    public interface ICandidatoRepositorio
    {
        void Adicionar(Candidato candidato);

        Candidato BuscarPeloId(Guid id);
    }
}
