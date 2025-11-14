using Google_GenerativeAI;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic; 
using System.Threading.Tasks;  


namespace UniManagement.Api.Services
{
    public class GeminiService : IAIService
    {
        private readonly GenerativeModel _geminiClient;

        public GeminiService(IConfiguration configuration)
        {
            var apiKey = configuration["GoogleAI:ApiKey"]; // Busca a chave do appsettings
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey), "API Key do Google AI (Gemini) não encontrada no appsettings.json");
            }

            _geminiClient = new GenerativeModel(apiKey: apiKey, model: "gemini-1.5-flash");
        }

        public async Task<AIResponse> AnalisarChamadoAsync(string descricao)
        {
            string prompt = $@"
                Você é um assistente de suporte técnico eficiente para a empresa UNI Management.
                Um funcionário relatou o seguinte problema: '{descricao}'.
                1. Analise o problema.
                2. Se for um problema MUITO comum e simples (resetar senha, conectar wifi, impressora sem papel/desligada) 
                   e você tiver certeza da solução, retorne a solução direta e curta em português brasileiro, começando EXATAMENTE com 'Sugestão:'.
                3. Se o problema for vago, complexo, precisar de mais detalhes, ou você não tiver certeza absoluta da solução, 
                   retorne EXATAMENTE a palavra 'ABRIR_CHAMADO'.
                Responda APENAS com a sugestão ou com 'ABRIR_CHAMADO'.";

            try
            {
                var response = await _geminiClient.GenerateContentAsync(prompt);
                string resposta = response.Text.Trim();

                if (resposta.StartsWith("Sugestão:"))
                {
                    return new AIResponse
                    {
                        SolucaoEncontrada = true,
                        SolucaoSugerida = resposta.Replace("Sugestão:", "").Trim(),
                        Confianca = 0.95
                    };
                }
                else
                {
                    return new AIResponse { SolucaoEncontrada = false, Confianca = 0 };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao chamar API Gemini (gunpal5): {ex.Message}");
                return new AIResponse { SolucaoEncontrada = false, Confianca = 0 };
            }
        }
    }
}
