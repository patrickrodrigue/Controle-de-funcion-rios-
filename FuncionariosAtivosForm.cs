using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Controle
{
    public class FuncionariosAtivosForm : Form
    {
        private DataGridView dataGridView;
        private Button novoFuncionarioButton;

        public FuncionariosAtivosForm()
        {
            // Configurações do formulário
            this.Text = "Funcionários Ativos";
            this.Width = 800;
            this.Height = 800;
            this.BackColor = Color.FromArgb(240, 240, 255);

            // Inicializando o DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Top,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Height = 200
            };
            this.Controls.Add(dataGridView);

            // Botão para adicionar um novo funcionário
            novoFuncionarioButton = new Button
            {
                Text = "Novo Funcionário",
                Font = new Font("Arial", 10, FontStyle.Regular),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 320)
            };
            novoFuncionarioButton.FlatAppearance.BorderSize = 1;
            novoFuncionarioButton.FlatAppearance.BorderColor = Color.FromArgb(65, 105, 225);
            novoFuncionarioButton.Click += NovoFuncionarioButton_Click;
            this.Controls.Add(novoFuncionarioButton);

            // Carregar dados ao abrir o formulário
            Load += FuncionariosAtivosForm_Load;
        }

        private void FuncionariosAtivosForm_Load(object sender, EventArgs e)
        {
            // Carrega os funcionários ativos no DataGridView
            CarregarFuncionariosAtivos();
        }

       private void CarregarFuncionariosAtivos()
{
    // Query SQL para buscar todos os funcionários
    string query = "SELECT nome, cpf, cargo, salario, data_admissao, observacao_saude, ferias, data_nascimento FROM funcionarios";

    using (var connection = new DatabaseConnection().GetConnection())
    {
        if (connection != null)
        {
            try
            {
                using (var command = new MySqlCommand(query, connection))
                using (var adapter = new MySqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    int rowsAffected = adapter.Fill(dataTable);

                    // Verifica se há registros para exibir
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Nenhum funcionário encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Configura o DataGridView para exibir os dados
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro ao buscar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Falha na conexão com o banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

        private void NovoFuncionarioButton_Click(object sender, EventArgs e)
        {
            // Abre o formulário de cadastro de novo funcionário
            MeuFormulario meuFormulario = new MeuFormulario();
            meuFormulario.ShowDialog();

            // Recarrega a lista de funcionários após o cadastro
            CarregarFuncionariosAtivos();
        }
    }
}
