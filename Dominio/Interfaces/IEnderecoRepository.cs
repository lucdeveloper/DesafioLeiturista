using Domain.Entidades;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public  interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task<Endereco> ObterPorCliente(long id);
    }
}