using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<List<Cliente>> ObterTodosClientes();

        Task<List<Cliente>> ObterPorNome(string nome);

        Task<Cliente> ObterClientePorId(long id);
    }
}