using Domain.Entidades;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public  interface IClienteService
    {
        Task<bool> Adicionar(Cliente cliente);

        Task<bool> Atualizar(Cliente cliente);
    }
}