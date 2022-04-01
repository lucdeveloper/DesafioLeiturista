using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOcorrenciaRepository : IBaseRepository<Ocorrencia>
    {
        Task<List<Ocorrencia>> ObterPorDescricao(string descricao);

        Task<Ocorrencia> ObterOcorrenciaPorId(long id);
    }
}