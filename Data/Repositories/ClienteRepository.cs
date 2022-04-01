using Data.DataContext;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Servicos.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextoDados context) : base(context)
        {
        }

        public async Task<List<Cliente>> ObterPorNome(string nome)
        {
            var cliente = await _context.Cliente.Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                                                .AsNoTracking()
                                                .Include(p => p.Endereco)
                                                .ToListAsync();

            return cliente;
        }

        public async Task<Cliente> ObterClientePorId(long id)
        {
            var cliente = await _context.Cliente.Where(p => p.Id == id)
                                                .AsNoTracking()
                                                .Include(p => p.Endereco)
                                                .FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<List<Cliente>> ObterTodosClientes()
        {
            var cliente = await _context.Cliente.AsNoTracking()
                                                .Include(p => p.Endereco)
                                                .ToListAsync();

            return cliente;
        }
    }
}
