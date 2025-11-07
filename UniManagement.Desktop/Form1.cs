// 1. Usamos os namespaces do seu projeto e da sua API
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UniManagement.Api.Entities; // <-- Importa os modelos da sua API
using UniManagement.Desktop.Services; // <-- Importa seu ApiService

// 2. O namespace deve ser o do SEU projeto desktop
namespace UniManagement.Desktop
{
    public partial class Form1 : Form
    {
        // 3. Campos para o serviço da API e a lista mestre de chamados
        private readonly ApiService _apiService;
        private List<Chamado> _todosOsChamados = new List<Chamado>();

        public Form1()
        {
            InitializeComponent();
            // 4. Inicializa o serviço da API
            _apiService = new ApiService();
        }

        // 5. O Form_Load agora é 'async' para poder chamar a API
        private async void Form1_Load(object sender, EventArgs e)
        {
            lblUsuarioLogado.Text = "Usuário: Ana Beatriz"; // Simulação mantida
            ConfigurarDataGridView();

            // 6. Chama o método para buscar dados reais
            await CarregarDadosDaApi();
        }

        // 7. Configura as colunas do DataGridView manualmente
        private void ConfigurarDataGridView()
        {
            dgvChamados.AutoGenerateColumns = false; // Não gera colunas sozinho
            dgvChamados.Columns.Clear();

            // Adiciona as colunas que queremos, na ordem que queremos
            dgvChamados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id_Chamado",
                HeaderText = "ID",
                DataPropertyName = "Id_Chamado"
            });

            dgvChamados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeFuncionario",
                HeaderText = "Funcionário",
                DataPropertyName = "NomeFuncionario"
            });

            dgvChamados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Prioridade",
                HeaderText = "Prioridade",
                DataPropertyName = "Prioridade"
            });

            dgvChamados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Data_Abertura",
                HeaderText = "Abertura",
                DataPropertyName = "Data_Abertura"
            });

            dgvChamados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status"
            });
        }

        // 8. Novo método para buscar dados da API
        private async Task CarregarDadosDaApi()
        {
            // Busca os dados reais da sua API
            _todosOsChamados = await _apiService.GetChamadosAsync();
            if (_todosOsChamados == null) _todosOsChamados = new List<Chamado>();

            // Atualiza o Grid com os dados buscados
            AtualizarGrid(_todosOsChamados);
        }

        // 9. Novo método para filtrar e exibir os dados
        private void AtualizarGrid(List<Chamado> chamados)
        {
            // "Projeta" os dados da API para um formato simples que o grid entende
            var dadosParaExibir = chamados.Select(c => new
            {
                c.Id_Chamado,
                NomeFuncionario = c.Funcionario?.Nome ?? "N/A", // Pega o nome do funcionário
                c.Prioridade,
                c.Data_Abertura,
                c.Status
            }).ToList();

            dgvChamados.DataSource = dadosParaExibir;
        }

        // 10. Método de pesquisa ATUALIZADO para usar os nomes corretos
        private void txtPesquisa_TextChanged_1(object sender, EventArgs e)
        {
            if (_todosOsChamados == null) return;

            string termoPesquisa = txtPesquisa.Text.ToLower();

            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                AtualizarGrid(_todosOsChamados); // Mostra todos
                return;
            }

            // Filtra a lista mestre (_todosOsChamados)
            var chamadosFiltrados = _todosOsChamados.Where(chamado =>
                chamado.Id_Chamado.ToString().Contains(termoPesquisa) ||
                (chamado.Funcionario?.Nome.ToLower().Contains(termoPesquisa) ?? false) ||
                chamado.Status.ToLower().Contains(termoPesquisa)
            ).ToList();

            // Atualiza o grid com os dados filtrados
            AtualizarGrid(chamadosFiltrados);
        }

        // 11. O código de pintura das células (colocamos o nome correto da coluna)
        private void dgvChamados_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verifica se estamos na coluna "Prioridade" e não é o cabeçalho
            if (e.RowIndex >= 0 && dgvChamados.Columns[e.ColumnIndex].Name == "Prioridade")
            {
                e.PaintBackground(e.CellBounds, true);

                if (e.Value != null)
                {
                    string prioridade = e.Value.ToString();
                    Brush tagBrush = Brushes.Gray;

                    switch (prioridade.ToUpper())
                    {
                        case "ALTA":
                            tagBrush = new SolidBrush(Color.FromArgb(231, 76, 60)); // Vermelho
                            break;
                        case "MÉDIA":
                            tagBrush = new SolidBrush(Color.FromArgb(243, 156, 18)); // Laranja
                            break;
                        case "BAIXA":
                            tagBrush = new SolidBrush(Color.FromArgb(46, 204, 113)); // Verde
                            break;
                    }

                    int tagWidth = 60;
                    int tagHeight = 20;
                    int tagX = e.CellBounds.X + (e.CellBounds.Width - tagWidth) / 2;
                    int tagY = e.CellBounds.Y + (e.CellBounds.Height - tagHeight) / 2;
                    Rectangle tagRect = new Rectangle(tagX, tagY, tagWidth, tagHeight);

                    e.Graphics.FillRectangle(tagBrush, tagRect);

                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    e.Graphics.DrawString(prioridade, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.White, tagRect, sf);
                    e.Handled = true;
                }
            }
        }

        // 12. Funções de clique vazias (mantidas do designer)
        private void label1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
    }
}