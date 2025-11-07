using System.Collections.Generic;

namespace UniManagement.Api.Entities
{
    public class Funcionario
    {
        public int Id_Matricula { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Cargo { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
    }
}