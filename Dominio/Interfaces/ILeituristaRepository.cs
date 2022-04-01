using Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILeituristaRepository : IBaseRepository<Leiturista>
    {
        Task<Leiturista> ObterPorMatricula(long Matricula);
        
        Task<List<Leiturista>> ObterPorNome(string Nome);
        
        Task<Leiturista> ObterFornecedorPorId(long id);
        
        Task<List<Leiturista>> ObterPorStatus(bool Status);
    }
}