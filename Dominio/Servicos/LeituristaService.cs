using Domain.Entidades;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class LeituristaService : ServicoBase, ILeituristaService
    {
        private readonly ILeituristaRepository _leituristaRepository;

        public LeituristaService(ILeituristaRepository leituristaRepository,
                                 INotificacao notificacao) : base(notificacao)
        {
            _leituristaRepository = leituristaRepository;
        }

        public async Task<bool> Adicionar(Leiturista leiturista)
        {
            var verificaPorMatricula = _leituristaRepository.Buscar(p => p.Matricula == leiturista.Matricula).Result.Any();

            if (verificaPorMatricula)
            {
                Notificar("Já existe um leiturista com a matricula informada");
                return false;
            }

            await _leituristaRepository.Adicionar(leiturista);

            return true;
        }

        public  bool VerificaLeituristaAtivo(bool status)
        {
           if(status == true)
            {
                return true;
            }

          return false;
        }

        public async Task<bool> Remover(long id, bool status)
        {
            if (VerificaLeituristaAtivo(status))
            {
                Notificar("Não foi possivel excluir, fornecedor ativo !");
                return false;
            }

           await _leituristaRepository.Remover(id);
           return true;
        }

        public void Dispose()
        {
            _leituristaRepository?.Dispose();
        }

        public async Task<bool> Atualizar(Leiturista leiturista)
        {
            var verificaPorId = _leituristaRepository.Buscar(p => p.Id == leiturista.Id).Result.Any();

            if (verificaPorId)
            {
                await _leituristaRepository.Atualizar(leiturista);
                return true;
            }

            Notificar("Nenhum leiturista encontrado com o Id informado!");
            return false;
        }
    }
}