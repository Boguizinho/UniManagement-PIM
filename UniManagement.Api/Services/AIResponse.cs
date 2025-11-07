namespace UniManagement.Api.Services
{
    public class AIResponse
    {
        public bool SolucaoEncontrada { get; set; }
        public string SolucaoSugerida { get; set; } = string.Empty;
        public double Confianca { get; set; }
    }
}