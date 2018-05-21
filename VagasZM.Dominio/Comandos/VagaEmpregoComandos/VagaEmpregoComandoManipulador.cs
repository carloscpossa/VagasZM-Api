using FluentValidator;
using System;
using VagasZM.Compartilhado.Comandos;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Entradas;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Mapeamento;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Saidas;
using VagasZM.Dominio.Repositorios;

namespace VagasZM.Dominio.Comandos.VagaEmpregoComandos
{
    public class VagaEmpregoComandoManipulador : Notifiable,
        IManipuladorComando<InserirVagaEmpregoComando>
    {
        private readonly IVagaEmpregoRepositorio _vagaEmpregoRepositorio;
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly IAreaProfissionalRepositorio _areaProfissionalRepositorio;
        private readonly ITipoContratacaoRepositorio _tipoContratacaoRepositorio;

        private readonly IVagaEmpregoComandoMap _vagaEmpregoMap;
        public VagaEmpregoComandoManipulador(IVagaEmpregoRepositorio vagaEmpregoRepositorio, 
                                             IEmpresaRepositorio empresaRepositorio, 
                                             IVagaEmpregoComandoMap vagaEmpregoMap,
                                             IAreaProfissionalRepositorio areaProfissionalRepositorio,
                                             ITipoContratacaoRepositorio tipoContratacaoRepositorio)
        {
            _vagaEmpregoRepositorio = vagaEmpregoRepositorio;
            _empresaRepositorio = empresaRepositorio;
            _vagaEmpregoMap = vagaEmpregoMap;
            _areaProfissionalRepositorio = areaProfissionalRepositorio;
            _tipoContratacaoRepositorio = tipoContratacaoRepositorio;
        }

        public IResultadoComando Manipular(InserirVagaEmpregoComando comando)
        {
            if (comando == null)
            {
                AddNotification("Dados", "Os dados para inclusão da vaga de emprego não foram informados corretamente.");
                return null;
            }

            var empresa = _empresaRepositorio.BuscaEmpresaPorId(comando.EmpresaId);                                    
            var areaProfissional = _areaProfissionalRepositorio.BuscaAreaProfissionalPorId(comando.AreaProfissionalId);                        
            var tipoContratacao = _tipoContratacaoRepositorio.BuscaTipoContratacaoPorId(comando.TipoContratacaoId);            

            var vagaEmprego = _vagaEmpregoMap.CriarVagaEmprego(comando, empresa, areaProfissional, tipoContratacao);

            AddNotifications(vagaEmprego.Notifications);

            if (!IsValid())
                return null;

            _vagaEmpregoRepositorio.Adicionar(vagaEmprego);

            return new InserirVagaEmpregoResultadoComando { VagaEmpregoId = vagaEmprego.Id };
        }
    }
}
