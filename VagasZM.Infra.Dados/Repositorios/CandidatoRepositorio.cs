using System;
using System.Linq;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Contexto;

namespace VagasZM.Infra.Dados.Repositorios
{
    public class CandidatoRepositorio : ICandidatoRepositorio
    {
        private readonly VagasZMDataContext _contexto;
        public CandidatoRepositorio(VagasZMDataContext contexto)
        {
            _contexto = contexto;
        }
        public void Adicionar(Candidato candidato)
        {
            _contexto.Candidato.Add(candidato);            
        }

        public Candidato BuscarPeloId(Guid id)
        {
            return _contexto
                        .Candidato
                        .Include("FormacaoEscolar")
                        .Include("ExperienciaProfissional")
                        .FirstOrDefault(x => x.Id == id);
        }
    }
}
