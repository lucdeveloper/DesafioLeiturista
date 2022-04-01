using Domain.Entidades;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILeituraService
    {
        Task<bool> Adicionar(Leitura leitura);
        Task<bool> Atualizar(Leitura leitura);
    }
}