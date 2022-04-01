using Data.DataContext;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Servicos.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ContextoDados context) : base(context)
        {
         
        }

        public async Task<Usuario> ObterLoginUsuario(string email)
        {
            var usuario = await _context.Usuario.Where(p => p.Email.ToLower().Contains(email.ToLower()))
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<List<Usuario>> ObterPorEmail(string email)
        {
            var usuario = await _context.Usuario.Where(p => p.Email.ToLower().Contains(email.ToLower()))
                                                .AsNoTracking()
                                                .ToListAsync();
            return usuario;
        }

        public async Task<Usuario> ObterUsuarioPorId(long id)
        {
            var usuario = await  _context.Usuario.Where(p => p.Id == id)
                                                 .AsNoTracking()
                                                 .FirstOrDefaultAsync();
            return usuario;
        }
    }
}