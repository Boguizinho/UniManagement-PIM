using System.Threading.Tasks;

namespace UniManagement.Api.Services
{
    public interface IAIService
    {
        Task<AIResponse> AnalisarChamadoAsync(string descricao);
    }
}
