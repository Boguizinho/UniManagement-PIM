using System;

namespace UniManagement.Api.Entities
{
    public class Chamado
    {
        public int Id_Chamado { get; set; }
        public int Id_Matricula_Funcionario { get; set; }
        public int? Id_Analista_Atribuido { get; set; }
        public DateTime Data_Abertura { get; set; }
        public string Prioridade { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public virtual Funcionario Funcionario { get; set; }
        public virtual Analista Analista { get; set; }
    }
}