using Domain.Entidades;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class OcorrenciaService : ServicoBase, IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public OcorrenciaService(INotificacao notificador,
            IOcorrenciaRepository ocorrenciaRepository) : base(notificador)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public async Task<bool> Adicionar(Ocorrencia ocorrencia)
        {
            var verificaPorDescricao = _ocorrenciaRepository.Buscar(p => p.Descricao == ocorrencia.Descricao).Result.Any();

            if (verificaPorDescricao)
            {
                Notificar("Já existe uma ocorrencia com a descrição informada!");
                return false;
            }

            await _ocorrenciaRepository.Adicionar(ocorrencia);

            return true;
        }

        public async Task<bool> Atualizar(Ocorrencia ocorrencia)
        {
            var verificaPorId = _ocorrenciaRepository.Buscar(p => p.Id == ocorrencia.Id).Result.Any();

            if (verificaPorId)
            {
                await _ocorrenciaRepository.Atualizar(ocorrencia);
                return true;
            }

            Notificar("Nenhuma ocorrencia encontrada com o Id informado!");
            return false; ;
        }

        public void Dispose()
        {
            _ocorrenciaRepository?.Dispose();
        }
    }
}
