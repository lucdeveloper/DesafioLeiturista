using Domain.Entidades;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOcorrenciaService : IDisposable
    {
        Task<bool> Adicionar(Ocorrencia ocorrencia);
        Task<bool> Atualizar(Ocorrencia ocorrencia);
    }
}