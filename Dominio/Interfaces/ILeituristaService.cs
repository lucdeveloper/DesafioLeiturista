using Domain.Entidades;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILeituristaService : IDisposable
    {
        Task<bool> Adicionar(Leiturista leiturista);

        Task<bool> Atualizar(Leiturista leiturista);

        bool VerificaLeituristaAtivo(bool status);

        Task<bool> Remover(long id, bool status);
    }
}
