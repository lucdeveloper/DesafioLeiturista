using Domain.Entidades;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class ClienteService : ServicoBase, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public ClienteService(INotificacao notificador,
                                  IClienteRepository clienteRepository, 
                                  IEnderecoRepository enderecoRepository) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!VerificaExistenciaCpf(cliente))
            {
                return false;
            }

            await _clienteRepository.Adicionar(cliente);

            return true;
        }

        private bool VerificaExistenciaCpf(Cliente cliente)
        {
            var verificaClienteCadastrado = _clienteRepository.Buscar(p => p.Cpf == cliente.Cpf).Result.Any();

            if (verificaClienteCadastrado)
            {
                Notificar("Já existe um cliente com o CPF informado");
                return false;
            }

            return true;
        }

        public async Task<bool> Atualizar(Cliente cliente)
        {
            var verificaPorId = _clienteRepository.Buscar(p => p.Id == cliente.Id).Result.Any();

            if (verificaPorId)
            {
                await _clienteRepository.Atualizar(cliente);
                return true;
            }

            Notificar("Nenhum cliente encontrado com o Id informado!");
            return false;
        }  
    }
}