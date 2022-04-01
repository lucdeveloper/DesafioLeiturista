using Data.DataContext;
using Domain.Entidades;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Servicos.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base, new()
    {
        protected readonly ContextoDados _context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ContextoDados context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<TEntity> ObterPorId(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(long id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges(); 
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
