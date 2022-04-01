using Domain.Entidades;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class LeituraService : ServicoBase, ILeituraService
    {
        private readonly ILeituraRepository _leituraRepository;
        private readonly ILeituristaRepository _leituristaRepository;
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly IClienteRepository _clienteRepository;

        public LeituraService(INotificacao notificador,
                              ILeituraRepository leituraRepository, 
                              ILeituristaRepository leituristaRepository,
                              IOcorrenciaRepository ocorrenciaRepository,
                              IClienteRepository clienteRepository) : base(notificador)
        {
            _leituraRepository = leituraRepository;
            _leituristaRepository = leituristaRepository;
            _ocorrenciaRepository = ocorrenciaRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Leitura leitura)
        {
            if (!await ValidaLeiturista(leitura))
            {
                return false;
            }

            if (!await ValidaCliente(leitura))
            {
                return false;
            }

            ObterDadosLeituraAnterior(leitura);

            if (!await ValidaStatusOcorrencia(leitura))
            {
                return false;
            }

            await _leituraRepository.Adicionar(leitura);
            return true;
        }

        private async void ObterDadosLeituraAnterior(Leitura leitura)
        {
            var obterLeituraAnterior = await _leituraRepository.ObterLeituraAnteriror(leitura.ClienteId);
            leitura.LeituraAnterior = (long)obterLeituraAnterior.LeituraAtual;

            if (leitura.LeituraAtual < leitura.LeituraAnterior)
            {
                leitura.OcorrenciaId = 7;
            }
        }

        private async Task<bool> ValidaLeiturista(Leitura leitura)
        {
            var Leiturista = await _leituristaRepository.ObterPorId(leitura.LeituristaId);

            if (!ValidacoesLeiturista(Leiturista))
            {
                return false;
            }
            return true;
        }

        private bool ValidacoesLeiturista(Leiturista leiturista)
        {
            if (leiturista == null)
            {
                Notificar("Leiturista não cadastrado ! ");
                return false;
            }

            if (leiturista.Ativo == false)
            {
                Notificar("Não foi possivel realizar a leitura. Leiturista inativo!");
                return false;
            }
            return true;
        }

        private async Task<bool> ValidaCliente(Leitura leitura)
        {
            var obtemcliente = await _clienteRepository.ObterPorId(leitura.ClienteId);

            if (obtemcliente == null)
            {
                Notificar("Cliente não cadastrado ! ");
                return false;
            }
            return true;
        }

        private async Task<bool> ValidaStatusOcorrencia(Leitura leitura)
        {
            var obterDadosOcorrencia = await _ocorrenciaRepository.ObterPorId(leitura.OcorrenciaId);

            if(obterDadosOcorrencia == null)
            {
                Notificar("Ocorrencia não cadastrado ! ");
                return false;
            }
            
            if (obterDadosOcorrencia.PermiteLeitura == false)
            {
                leitura.LeituraAtual = null;
            }

            return true;
        }

        public async Task<bool> Atualizar(Leitura leitura)
        {
            var verificaPorId = _leituraRepository.Buscar(p => p.Id == leitura.Id).Result.Any();

            if (verificaPorId)
            {
                if (!await ValidaLeiturista(leitura))
                {
                    return false;
                }

                if (!await ValidaCliente(leitura))
                {
                    return false;
                }

                ObterDadosLeituraAnterior(leitura);

                if (!await ValidaStatusOcorrencia(leitura))
                {
                    return false;
                }

                await _leituraRepository.Atualizar(leitura);
                return true;
            }

            Notificar("Nenhuma Lietura foi encontrada com o Id informado!");
            return false;
        }
    }
}