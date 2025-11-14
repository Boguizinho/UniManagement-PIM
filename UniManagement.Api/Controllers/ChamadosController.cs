using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniManagement.Api.Data;
using UniManagement.Api.Entities;
using UniManagement.Api.Services; // <-- Importante: usar a interface
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAIService _aiService; // <-- Injeta a INTERFACE

        // O construtor  recebe o DbContext e o IAIService
        public ChamadosController(ApplicationDbContext context, IAIService aiService)
        {
            _context = context;
            _aiService = aiService;
        }

        // GET: api/chamados (Para listar os chamados)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chamado>>> GetChamados()
        {
            return await _context.TbChamados
                                 .Include(c => c.Funcionario)
                                 .Include(c => c.Analista)
                                 .OrderByDescending(c => c.Data_Abertura)
                                 .ToListAsync();
        }

        // POST: api/chamados/abrir (Para criar um novo chamado)
        [HttpPost("abrir")]
        public async Task<ActionResult<object>> AbrirChamado([FromBody] Chamado novoChamadoRequest)
        {
            if (novoChamadoRequest == null || string.IsNullOrWhiteSpace(novoChamadoRequest.Descricao))
            {
                return BadRequest("Descrição do chamado é obrigatória.");
            }

            // 1. Analisa com a IA ( usando o GeminiService)
            var aiResponse = await _aiService.AnalisarChamadoAsync(novoChamadoRequest.Descricao);

            // 2. Se a IA deu sugestão, retorna a sugestão
            if (aiResponse.SolucaoEncontrada)
            {
                return Ok(new
                {
                    status = "sugestao",
                    mensagem = aiResponse.SolucaoSugerida
                });
            }
            else
            {
                // 3. IA não resolveu -> Salva o chamado no banco
                var chamadoParaSalvar = new Chamado
                {
                    // Usando ID 1 como padrão se não vier do frontend
                    Id_Matricula_Funcionario = novoChamadoRequest.Id_Matricula_Funcionario > 0 ? novoChamadoRequest.Id_Matricula_Funcionario : 1,
                    Descricao = novoChamadoRequest.Descricao,
                    Prioridade = novoChamadoRequest.Prioridade ?? "Média",
                    Data_Abertura = DateTime.Now,
                    Status = "Aberto"
                };

                _context.TbChamados.Add(chamadoParaSalvar);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    status = "aberto",
                    mensagem = $"Chamado #{chamadoParaSalvar.Id_Chamado} aberto com sucesso.",
                    chamadoId = chamadoParaSalvar.Id_Chamado
                });
            }
        }
    }
}
