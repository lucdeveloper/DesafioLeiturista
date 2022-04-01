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
    [Route("api/ocorrencia")]
    [Authorize(Roles = "Somente Leitura")]
    public class OcorrenciaController : ControllerConfig
    {
        private readonly IMapper _mapper;
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly IOcorrenciaService _ocorrenciaService;

        public OcorrenciaController(INotificacao notificacao,
                                    IMapper mapper,
                                    IOcorrenciaRepository ocorrenciaRepository,
                                    IOcorrenciaService ocorrenciaService) : base(notificacao)
        {
            _mapper = mapper;
            _ocorrenciaRepository = ocorrenciaRepository;
            _ocorrenciaService = ocorrenciaService;
        }

        [HttpGet]
        public async Task<IEnumerable<OcorrenciaViewModel>> Obter()
        {
            var ocorrencias = _mapper.Map<IEnumerable<OcorrenciaViewModel>> (await _ocorrenciaRepository.ObterTodos());

            return ocorrencias;
        }

        [HttpGet("{descricao}")]
        public async Task<IEnumerable<OcorrenciaViewModel>> ObterPorDescricao(string descricao)
        {
            var ocorrencias = _mapper.Map<IEnumerable<OcorrenciaViewModel>>(await _ocorrenciaRepository.ObterPorDescricao(descricao));

            return ocorrencias;
        }

        [HttpPost]
        public async Task<ActionResult<OcorrenciaViewModel>> Adicionar(OcorrenciaViewModel ocorrenciaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _ocorrenciaService.Adicionar(_mapper.Map<Ocorrencia>(ocorrenciaViewModel));

            return RetornoOperacao(ocorrenciaViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OcorrenciaViewModel>> Excluir(long id)
        {
            var ocorrencia = _mapper.Map<OcorrenciaViewModel>(await _ocorrenciaRepository.ObterOcorrenciaPorId(id));

            if (ocorrencia == null)
            {
                return NotFound();
            }

            await _ocorrenciaRepository.Remover(id);

            return RetornoOperacao();
        }

        [HttpPut]
        public async Task<ActionResult<OcorrenciaViewModel>> Alterar(OcorrenciaViewModel ocorrenciaViewModel)
        {
            var ocorrencia = _mapper.Map<Ocorrencia>(ocorrenciaViewModel);

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _ocorrenciaService.Atualizar(ocorrencia);

            return RetornoOperacao(ocorrencia);
        }
    }
 }