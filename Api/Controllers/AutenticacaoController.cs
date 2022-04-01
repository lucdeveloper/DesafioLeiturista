using Api.Configuracao;
using Api.ViewModels;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/Login")]
    public class AutenticacaoController : ControllerConfig
    {
        private readonly AppSettings _appSettings;
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacaoController(INotificacao notificacao,
                               IOptions<AppSettings> appSettings,
                               IUsuarioRepository usuarioRepository) : base(notificacao)
        {
            _appSettings = appSettings.Value;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel usuario)
        {
            if (!ModelState.IsValid) 
            {
               return CustomResponse(ModelState);
            } 

            var usuariosConsutado = await _usuarioRepository.ObterLoginUsuario(usuario.Email);

            if(usuariosConsutado == null)
            {
                NotificarError("Usuário ou Senha incorretos");
            }

            return  ValidaEAtualizaSenha(usuario, usuariosConsutado.Senha, usuariosConsutado.Cargo);

        }

        private ActionResult ValidaEAtualizaSenha(LoginUserViewModel usuario, string senhaHash, string perfil)
        {
            var senha = new PasswordHasher<LoginUserViewModel>();
            var status = senha.VerifyHashedPassword(usuario, senhaHash, usuario.Password);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return RetornoOperacao("Usuário ou Senha incorretos");
                    
                case PasswordVerificationResult.Success:
                    return RetornoOperacao(GerarJwt(usuario, perfil));
                   
                case PasswordVerificationResult.SuccessRehashNeeded:
                    return RetornoOperacao(); 
                
                default:
                    throw new InvalidOperationException(); 
            }
        }

        private RetornoLoginViewModel GerarJwt(LoginUserViewModel usuario, string perfil)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,usuario.Email),
                    new Claim(ClaimTypes.Role,perfil)
                }),

                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new RetornoLoginViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
            };

            return response;
        }

    }
}
