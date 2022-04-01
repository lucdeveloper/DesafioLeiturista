using Api.ViewModels;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/usuario")]
    [Authorize(Roles = "Admin")]
    public class UsuarioController : ControllerConfig
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(INotificacao notificacao,
                                 IMapper mapper,
                                 IUsuarioRepository usuarioRepository, 
                                 IUsuarioService usuarioService) : base(notificacao)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> Obter()
        {
            var usuarios = _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos());

            return usuarios;
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> ObterPorEmail(string email) {

            var usuarios = _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterPorEmail(email));
  
            return RetornoOperacao(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            ConverterSenhaEmHasch(usuarioViewModel);

            await _usuarioService.Adicionar(_mapper.Map<Usuario>(usuarioViewModel));
            return RetornoOperacao(usuarioViewModel);
        }

        private void ConverterSenhaEmHasch(UsuarioViewModel usuarioViewModel)
        {
            var senha = new PasswordHasher<UsuarioViewModel>();
            usuarioViewModel.Senha = senha.HashPassword(usuarioViewModel, usuarioViewModel.Senha);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> Excluir(long id)
        {
            var usuario = _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterUsuarioPorId(id));

            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioRepository.Remover(id);

            return RetornoOperacao();
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioViewModel>> Alterar(UsuarioViewModel usuarioViewModel)
        {
            ConverterSenhaEmHasch(usuarioViewModel);

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _usuarioService.Atualizar(usuario);

            return RetornoOperacao(usuarioViewModel);
        }
    }
}