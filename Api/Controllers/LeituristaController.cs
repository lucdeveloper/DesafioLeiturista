using Api.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Entidades;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("api/leiturista")]
    [Authorize(Roles = "Somente Leitura")]
    public class LeituristaController : ControllerConfig
    {
        private readonly IMapper _mapper;
        private readonly ILeituristaRepository _leituristaRepository;
        private readonly ILeituristaService _leituristaService;

        public LeituristaController(IMapper mapper,
                                    ILeituristaRepository leituristaRepository,
                                    ILeituristaService leituristaService,
                                    INotificacao notificador) : base(notificador)
        {
            _mapper = mapper;
            _leituristaRepository = leituristaRepository;
            _leituristaService = leituristaService;
        }

        [HttpGet]
        public async Task<IEnumerable<LeituristaViewModel>> ObterLeituristas()
        {
            var listaLeituristas = _mapper.Map<IEnumerable<LeituristaViewModel>>(await _leituristaRepository.ObterTodos());

            return listaLeituristas;
        }

        [HttpGet("nome/{nome}")]
        public async Task<IEnumerable<LeituristaViewModel>> ObterPorNome(string nome)
        {
            var leiturista = _mapper.Map<IEnumerable<LeituristaViewModel>>(await _leituristaRepository.ObterPorNome(nome));

            return leiturista;
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<LeituristaViewModel>>> ObterPorStatus(bool status)
        {
            var leiturista = _mapper.Map<IEnumerable<LeituristaViewModel>>(await _leituristaRepository.ObterPorStatus(status));

            return RetornoOperacao(leiturista);
        }

        [HttpGet("matricula/{matricula}")]
        public async Task<ActionResult<LeituristaViewModel>> ObterPorMatricula(long matricula)
        {
            var leiturista = _mapper.Map<LeituristaViewModel>(await _leituristaRepository.ObterPorMatricula(matricula));

            if (leiturista == null)
            {
                return NotFound();
            }

            return leiturista;
        }

        [HttpPost]
        public async Task<ActionResult<LeituristaViewModel>> Adicionar(LeituristaViewModel leituristaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _leituristaService.Adicionar(_mapper.Map<Leiturista>(leituristaViewModel));

            return RetornoOperacao(leituristaViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LeituristaViewModel>> Excluir(long id)
        {
            var leiturista = _mapper.Map<LeituristaViewModel>(await _leituristaRepository.ObterFornecedorPorId(id));

            if (leiturista == null)
            {
                return NotFound();
            }

            var statusLeiturista = leiturista.Ativo;

            await _leituristaService.Remover(id, statusLeiturista);

            return RetornoOperacao();
        }

        [HttpPut]
        public async Task<ActionResult<LeituristaViewModel>> Alterar(LeituristaViewModel leituristaViewModel)
        { 
            var leiturista = _mapper.Map<Leiturista>(leituristaViewModel);

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _leituristaService.Atualizar(leiturista);

            return RetornoOperacao();
        }
    }
}