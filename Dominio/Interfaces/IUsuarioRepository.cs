using Domain.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<List<Usuario>> ObterPorEmail(string email);

        Task<Usuario> ObterUsuarioPorId(long id);

        Task<Usuario> ObterLoginUsuario(string email);
    }
}