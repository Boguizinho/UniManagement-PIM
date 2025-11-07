namespace UniManagement.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dgvChamados = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            txtPesquisa = new TextBox();
            lblUsuarioLogado = new Label();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvChamados).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvChamados
            // 
            dgvChamados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChamados.BackgroundColor = Color.White;
            dgvChamados.BorderStyle = BorderStyle.None;
            dgvChamados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(52, 73, 94);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvChamados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvChamados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChamados.Columns.AddRange(new DataGridViewColumn[] { Column1 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvChamados.DefaultCellStyle = dataGridViewCellStyle2;
            dgvChamados.EnableHeadersVisualStyles = false;
            dgvChamados.GridColor = Color.FromArgb(221, 221, 221);
            dgvChamados.Location = new Point(0, 65);
            dgvChamados.Name = "dgvChamados";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(0, 5, 0, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvChamados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvChamados.RowHeadersVisible = false;
            dgvChamados.RowTemplate.Height = 50;
            dgvChamados.Size = new Size(800, 445);
            dgvChamados.TabIndex = 0;
            dgvChamados.CellPainting += dgvChamados_CellPainting;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Column1.HeaderText = "Ver Detalhes";
            Column1.Name = "Column1";
            Column1.Width = 111;
            // 
            // txtPesquisa
            // 
            txtPesquisa.BorderStyle = BorderStyle.None;
            txtPesquisa.ForeColor = Color.White;
            txtPesquisa.Location = new Point(444, 24);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(101, 18);
            txtPesquisa.TabIndex = 1;
            txtPesquisa.TextChanged += txtPesquisa_TextChanged_1;
            // 
            // lblUsuarioLogado
            // 
            lblUsuarioLogado.AutoSize = true;
            lblUsuarioLogado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuarioLogado.ForeColor = Color.White;
            lblUsuarioLogado.Location = new Point(643, 21);
            lblUsuarioLogado.Name = "lblUsuarioLogado";
            lblUsuarioLogado.Size = new Size(127, 21);
            lblUsuarioLogado.TabIndex = 2;
            lblUsuarioLogado.Text = "Usuario logado";
            lblUsuarioLogado.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(243, 32);
            label1.TabIndex = 3;
            label1.Text = "Painel de Chamados";
            label1.Click += label1_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(44, 62, 80);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtPesquisa);
            panel1.Controls.Add(lblUsuarioLogado);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 70);
            panel1.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(542, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(44, 41);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(616, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(800, 510);
            Controls.Add(dgvChamados);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChamados).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvChamados;
        private TextBox txtPesquisa;
        private Label lblUsuarioLogado;
        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn Column1;
        private PictureBox pictureBox2;
    }
}
