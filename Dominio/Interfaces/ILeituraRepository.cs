using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILeituraRepository : IBaseRepository<Leitura>
    {
        Task<IEnumerable<Leitura>> ObterLeitura();

        Task<Leitura> ObterLeituraPorId(long id);

        Task<IEnumerable<Leitura>> ObterLeituraPorIdCliente(long id);

        Task<IEnumerable<Leitura>> ObterLeituraPorData(int data);
        Task<Leitura> ObterLeituraAnteriror(long clienteId);
    }
}