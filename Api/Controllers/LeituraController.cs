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
    [Route("/api/leitura")]
   // [Authorize(Roles = "Somente Leitura")]
    public class LeituraController : ControllerConfig
    {
        private readonly IMapper _mapper;
        private readonly ILeituraRepository _leituraRepository;
        private readonly ILeituraService _leituraService;

        public LeituraController(INotificacao notificacao,
                                 IMapper mapper,
                                 ILeituraRepository leituraRepository,
                                 ILeituraService leituraService ) : base(notificacao)
        {
            _mapper = mapper;
            _leituraRepository = leituraRepository;
            _leituraService = leituraService;
        }

        [HttpGet]
        public async Task<IEnumerable<LeituraViewModel>> Obter()    
        {
            var leitura = _mapper.Map<IEnumerable<LeituraViewModel>>(await _leituraRepository.ObterLeitura());
            return leitura;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LeituraViewModel>> ObterPorId(long id)
        {
            var leitura = _mapper.Map<LeituraViewModel>(await _leituraRepository.ObterLeituraPorId(id));

            if(leitura == null)
            {
                return NotFound();
            }

            return leitura;
        }

        [HttpGet("cliente/{id}")]
        public async Task<IEnumerable<LeituraViewModel>> ObterPorIdCliente(long id)
        {
            var leituraPorCliente = _mapper.Map<IEnumerable<LeituraViewModel>>(await _leituraRepository.ObterLeituraPorIdCliente(id));

            return leituraPorCliente;
        }

        [HttpGet("cliente/data/{mes}")]
        public async Task<IEnumerable<LeituraViewModel>> ObterPorIdCliente(int mes)
        {
            var leituraPorCliente = _mapper.Map<IEnumerable<LeituraViewModel>>(await _leituraRepository.ObterLeituraPorData(mes));

            return leituraPorCliente;
        }

        [HttpPost]
        public async Task<ActionResult<AdicionaLeituraViewModel>> Adicionar(AdicionaLeituraViewModel adicionaLeituraViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _leituraService.Adicionar(_mapper.Map<Leitura>(adicionaLeituraViewModel));

            return RetornoOperacao(adicionaLeituraViewModel);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var leitura = _mapper.Map<LeituraViewModel>(await _leituraRepository.ObterLeituraPorId(id));

            if (leitura == null)
            {
                return NotFound();
            }

            await _leituraRepository.Remover(id);

            return RetornoOperacao();
        }

        [HttpPut]

        public async Task<ActionResult<AdicionaLeituraViewModel>> Alterar(AdicionaLeituraViewModel adicionaLeituraViewModel)
        {
            var leitura = _mapper.Map<Leitura>(adicionaLeituraViewModel);

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _leituraService.Atualizar(leitura);

            return RetornoOperacao();
        }
    }
}