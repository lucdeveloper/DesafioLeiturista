using Api.ViewModels;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/cliente")]
    [Authorize(Roles = "Desenvolvedor")]
    public class ClienteController : ControllerConfig
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        public ClienteController(INotificacao notificacao,
                                 IMapper mapper,
                                 IClienteRepository clienteRepository, 
                                 IClienteService clienteService) : base(notificacao)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteViewModel>> Obter()
        {
            var clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodosClientes());

            return clientes;
        }

        [HttpGet("{nome}")]
        public async Task<IEnumerable<ClienteViewModel>> ObterPorNome(string nome)
        {
            var clientes = _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterPorNome(nome));

            return clientes;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Adicionar(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _clienteService.Adicionar(_mapper.Map<Cliente>(clienteViewModel));

            return RetornoOperacao(clienteViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteViewModel>> Delete(long id)
        {
            var leiturista = _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterClientePorId(id));

            if(leiturista == null)
            {
                return NotFound();
            }

           await _clienteRepository.Remover(id);

           return RetornoOperacao();
        }

        [HttpPut]
        public async Task<ActionResult<ClienteViewModel>> Alterar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
  
            await _clienteService.Atualizar(cliente);

            return RetornoOperacao();
        }
    }
}