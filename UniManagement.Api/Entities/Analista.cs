using System.Collections.Generic;

namespace UniManagement.Api.Entities
{
    public class Analista
    {
        public int Id_Analista { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Cargo { get; set; }
        public decimal? Avaliacao { get; set; }
        public virtual ICollection<Chamado> ChamadosAtribuidos { get; set; } = new List<Chamado>();
    }
}