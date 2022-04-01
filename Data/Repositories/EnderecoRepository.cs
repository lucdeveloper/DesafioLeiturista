using Data.DataContext;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Servicos.Repositories;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ContextoDados context) : base(context)
        {
        }

        public async Task<Endereco> ObterPorCliente(long id)
        {
            var endereco = await _context.Endereco.AsNoTracking().FirstOrDefaultAsync(c => c.ClienteID == id);

            return endereco;
        }
    }
}
