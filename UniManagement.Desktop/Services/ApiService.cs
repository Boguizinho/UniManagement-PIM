using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniManagement.Api.Entities;

namespace UniManagement.Desktop.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        // IMPORTANTE: Ajuste a porta para a mesma da sua API!
        private const string BaseUrl = "https://localhost:7004/";

        public ApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
        }

        public async Task<List<Chamado>> GetChamadosAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Chamado>>("api/chamados");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar com a API: {ex.Message}");
                return new List<Chamado>();
            }
        }
    }
}