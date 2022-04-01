using Domain.Entidades;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class UsuarioService : ServicoBase, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, 
                              INotificacao notificacao) : base(notificacao)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> Adicionar(Usuario usuario)
        {
            //var verificarUsuarioExistente = _usuarioRepository.Buscar(p => p.Email.ToLower().Contains(usuario.Email.ToLower())).Result.Any();
            var verificarUsuarioExistente = _usuarioRepository.Buscar(p => p.Email.ToLower() == usuario.Email.ToLower()).Result.Any();

            if (verificarUsuarioExistente)
            {
                Notificar("E-mail já pertence a um usuario!");
                return false;
            }
            await _usuarioRepository.Adicionar(usuario);
            return true;
        }

        public async Task<bool> Atualizar(Usuario usuario)
        {
            var verificaPorId = _usuarioRepository.Buscar(p => p.Id == usuario.Id).Result.Any();

            if (verificaPorId)
            {
                await _usuarioRepository.Atualizar(usuario);
                return true;
            }

            Notificar("Nenhum usuario encontrado com o Id informado!");
            return false;
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}
