using System.Threading.Tasks; // Adicionar este using

namespace UniManagement.Api.Services
{
    public interface IAIService
    {
        Task<AIResponse> AnalisarChamadoAsync(string descricao);
    }
}