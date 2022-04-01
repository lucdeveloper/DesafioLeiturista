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
    public class LeituristaRepository : BaseRepository<Leiturista>, ILeituristaRepository

    {
        public LeituristaRepository(ContextoDados context) : base(context)
        {}

        public async Task<Leiturista> ObterPorMatricula(long Matricula)
        {
            var leiturista = await _context.Leituristas.AsNoTracking().FirstOrDefaultAsync(p => p.Matricula == Matricula);

            return leiturista;
        }

        public async Task<List<Leiturista>> ObterPorNome(string Nome)
        {
            var leituristaPorNome = await _context.Leituristas.Where(x => x.Nome.ToLower().Contains(Nome)).ToListAsync();

            return leituristaPorNome;
        }

        public async Task<List<Leiturista>> ObterPorStatus(bool Status)
        {
            var leituristaPorStatus = await _context.Leituristas.Where(p => p.Ativo == Status).AsNoTracking().ToListAsync();

            return leituristaPorStatus;
        }

        public async Task<Leiturista> ObterFornecedorPorId(long id)
        {
            var leituristaPorStatus = await _context.Leituristas.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return leituristaPorStatus;
        }
    }
}
