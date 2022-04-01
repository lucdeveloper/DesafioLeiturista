using Domain.Entidades;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface  IUsuarioService : IDisposable
    {
        Task<bool> Atualizar(Usuario usuario);

        Task<bool> Adicionar(Usuario usuario);
    }
}