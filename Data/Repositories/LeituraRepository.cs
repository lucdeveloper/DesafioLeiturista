using Data.DataContext;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Servicos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LeituraRepository : BaseRepository<Leitura>, ILeituraRepository
    {
        public LeituraRepository(ContextoDados context) : base(context)
        {
        }

        public async Task<IEnumerable<Leitura>> ObterLeitura()
        {
            var leituras = await _context.Leitura.AsNoTracking()
                                         .Include(c => c.Cliente)
                                         .Include(c => c.Ocorrencia)
                                         .Include(c => c.Leiturista)
                                         .Include(c => c.Cliente.Endereco)
                                         .ToListAsync();
            return leituras;
        }

        public  async Task<Leitura> ObterLeituraPorId(long id)
        {
            var leitura = await _context.Leitura.AsNoTracking()
                                        .Include(c => c.Cliente)
                                        .Include(c => c.Leiturista)
                                        .Include(c => c.Ocorrencia)
                                        .Include(c => c.Cliente.Endereco)
                                        .FirstOrDefaultAsync(c => c.Id == id);
            return leitura;
        }

        public async Task<IEnumerable<Leitura>> ObterLeituraPorIdCliente(long idCliente)
        {

            var leituraCliente = await _context.Leitura.AsNoTracking()
                                               .Where(p => p.ClienteId == idCliente)
                                               .Include(c => c.Cliente)
                                               .Include(c => c.Leiturista)
                                               .Include(c => c.Ocorrencia)
                                               .Include(c => c.Cliente.Endereco)
                                               .ToListAsync();
            return leituraCliente;

        }

        public async Task<IEnumerable<Leitura>> ObterLeituraPorData(int data)
        {
            var leituras = await _context.Leitura.AsNoTracking()
                                                .Where(p => p.DataLeitura.Month == data)
                                                .Include(c => c.Cliente)
                                                .Include(c => c.Leiturista)
                                                .Include(c => c.Ocorrencia)
                                                .Include(c => c.Cliente.Endereco)
                                                .ToListAsync();
            return leituras;
        }

        public async Task<Leitura> ObterLeituraAnteriror(long clienteId)
        {
            var leituraAnterior = await _context.Leitura.AsNoTracking()
                                                        .Where(x => x.ClienteId == clienteId)
                                                        .OrderByDescending(c => c.LeituraAtual)
                                                        .FirstOrDefaultAsync();
            return leituraAnterior;
        }
    }
}