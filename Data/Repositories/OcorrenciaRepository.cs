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
    public class OcorrenciaRepository : BaseRepository<Ocorrencia>, IOcorrenciaRepository
    {
        public OcorrenciaRepository(ContextoDados context) : base(context)
        {
        }
        public Task<Ocorrencia> ObterOcorrenciaPorId(long id)
        {
            var ocorrenciaPorDescricao = _context.Ocorrencia.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return ocorrenciaPorDescricao;
        }

        public async Task<List<Ocorrencia>> ObterPorDescricao(string descricao)
        {
           var ocorrenciaPorDescricao = await _context.Ocorrencia.Where(x => x.Descricao.ToLower().Contains(descricao)).ToListAsync();

           return ocorrenciaPorDescricao;   
        }
    }
}