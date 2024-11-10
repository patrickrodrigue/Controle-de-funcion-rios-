using System;
using System.Drawing;
using System.Windows.Forms;
using Controle_de_funcionarios;
using MySql.Data.MySqlClient;

namespace Controle
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FuncionariosAtivosForm());
            }
            else
            {
                Application.Exit();
            }
        }
    }

    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection()
        {
            // Conexão com o banco de dados MySQL no XAMPP
            connectionString = "Server=localhost;Database=empresa;User ID=root;Password=;SslMode=none;";
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
            return connection;
        }
    }

    public class MeuFormulario : Form
    {
        private Button meuBotao;
        private Label meuLabel;
        private Label nomeLabel, nascimentoLabel, cpfLabel, admissaoLabel, salarioLabel, cargoLabel, saudeLabel, feriasLabel;
        private TextBox nomeTextBox, cpfTextBox, salarioTextBox, cargoTextBox, saudeTextBox, feriasTextBox;
        private DateTimePicker nascimentoPicker, admissaoPicker;
        private Label ruaLabel, numeroLabel, cidadeLabel, bairroLabel, cepLabel, complementoLabel;
        private TextBox ruaTextBox, numeroTextBox, cidadeTextBox, bairroTextBox, cepTextBox, complementoTextBox;

        public MeuFormulario()
        {
            // Configurações do formulário
            this.Text = "Controle de funcionários";
            this.Width = 500;
            this.Height = 600;
            this.BackColor = Color.FromArgb(240, 240, 255);

            // Configurando o label principal
            meuLabel = new Label();
            meuLabel.Text = "Novo funcionário:";
            meuLabel.AutoSize = true;
            meuLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            meuLabel.ForeColor = Color.FromArgb(70, 70, 150);
            meuLabel.Location = new Point(150, 20);
            this.Controls.Add(meuLabel);

            // Função para adicionar um rótulo e caixa de texto
            void AddLabelAndTextBox(ref Label label, ref TextBox textBox, string labelText, int yPosition)
            {
                label = new Label();
                label.Text = labelText;
                label.AutoSize = true;
                label.Font = new Font("Arial", 10, FontStyle.Regular);
                label.ForeColor = Color.FromArgb(70, 70, 150);
                label.Location = new Point(150, yPosition);
                this.Controls.Add(label);

                textBox = new TextBox();
                textBox.Font = new Font("Arial", 10, FontStyle.Regular);
                textBox.Location = new Point(150, yPosition + 20);
                textBox.Width = 200;
                this.Controls.Add(textBox);
            }


            // Campos para Nome
            AddLabelAndTextBox(ref nomeLabel, ref nomeTextBox, "Nome:", 50);

            // Campo para Data de Nascimento
            nascimentoLabel = new Label();
            nascimentoLabel.Text = "Data de Nascimento:";
            nascimentoLabel.AutoSize = true;
            nascimentoLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            nascimentoLabel.ForeColor = Color.FromArgb(70, 70, 150);
            nascimentoLabel.Location = new Point(150, 100);
            this.Controls.Add(nascimentoLabel);

            nascimentoPicker = new DateTimePicker();
            nascimentoPicker.Font = new Font("Arial", 10, FontStyle.Regular);
            nascimentoPicker.Location = new Point(150, 120);
            this.Controls.Add(nascimentoPicker);

            // Campo para CPF
            AddLabelAndTextBox(ref cpfLabel, ref cpfTextBox, "CPF:", 150);

            // Campo para Data de Admissão
            admissaoLabel = new Label();
            admissaoLabel.Text = "Data de Admissão:";
            admissaoLabel.AutoSize = true;
            admissaoLabel.Font = new Font("Arial", 10, FontStyle.Regular);
            admissaoLabel.ForeColor = Color.FromArgb(70, 70, 150);
            admissaoLabel.Location = new Point(150, 200);
            this.Controls.Add(admissaoLabel);

            admissaoPicker = new DateTimePicker();
            admissaoPicker.Font = new Font("Arial", 10, FontStyle.Regular);
            admissaoPicker.Location = new Point(150, 220);
            this.Controls.Add(admissaoPicker);

            // Campo para Salário
            AddLabelAndTextBox(ref salarioLabel, ref salarioTextBox, "Salário:", 250);

            // Campo para Cargo
            AddLabelAndTextBox(ref cargoLabel, ref cargoTextBox, "Cargo:", 300);

            // Campo para Observação de Saúde
            AddLabelAndTextBox(ref saudeLabel, ref saudeTextBox, "Observação de Saúde:", 350);

            // Campo para Férias
            AddLabelAndTextBox(ref feriasLabel, ref feriasTextBox, "Férias:", 400);
            // Campos para Endereço
            AddLabelAndTextBox(ref ruaLabel, ref ruaTextBox, "Rua:", 450);

            AddLabelAndTextBox(ref numeroLabel, ref numeroTextBox, "Número:", 500);

            AddLabelAndTextBox(ref cidadeLabel, ref cidadeTextBox, "Cidade:", 550);

            AddLabelAndTextBox(ref bairroLabel, ref bairroTextBox, "Bairro:", 600);

            AddLabelAndTextBox(ref cepLabel, ref cepTextBox, "CEP:", 650);

            AddLabelAndTextBox(ref complementoLabel, ref complementoTextBox, "Complemento:", 700);


            // Configurando o botão
            meuBotao = new Button();
            meuBotao.Text = "Cadastrar";
            meuBotao.Font = new Font("Arial", 10, FontStyle.Regular);
            meuBotao.Size = new Size(120, 40);
            meuBotao.BackColor = Color.FromArgb(100, 149, 237);
            meuBotao.ForeColor = Color.White;
            meuBotao.FlatStyle = FlatStyle.Flat;
            meuBotao.FlatAppearance.BorderSize = 1;
            meuBotao.FlatAppearance.BorderColor = Color.FromArgb(65, 105, 225);
            meuBotao.Location = new Point(180, 550);
            meuBotao.Click += new EventHandler(MeuBotao_Click);
            this.Controls.Add(meuBotao);
        }

        private void MeuBotao_Click(object sender, EventArgs e)
        {
            // Captura os dados preenchidos
            string nome = nomeTextBox.Text;
            DateTime dataNascimento = nascimentoPicker.Value;
            string cpf = cpfTextBox.Text;
            DateTime dataAdmissao = admissaoPicker.Value;
            decimal salario;
            decimal.TryParse(salarioTextBox.Text, out salario); // Tenta converter o salário para decimal
            string cargo = cargoTextBox.Text;
            string observacaoSaude = saudeTextBox.Text;
            string ferias = feriasTextBox.Text;

            // Dados de endereço
            string rua = ruaTextBox.Text;
            string numero = numeroTextBox.Text;
            string cidade = cidadeTextBox.Text;
            string bairro = bairroTextBox.Text;
            string cep = cepTextBox.Text;
            string complemento = complementoTextBox.Text;

            using (var connection = new DatabaseConnection().GetConnection())
            {
                if (connection != null) // Verifica se a conexão foi estabelecida
                {
                    // Inicia uma transação para garantir que ambas inserções sejam atômicas
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insere o funcionário na tabela `funcionarios`
                            string funcionarioQuery = "INSERT INTO funcionarios (nome, data_nascimento, cpf, data_admissao, salario, cargo, observacao_saude, ferias) " +
                                                      "VALUES (@Nome, @DataNascimento, @Cpf, @DataAdmissao, @Salario, @Cargo, @ObservacaoSaude, @Ferias)";

                            using (var funcionarioCommand = new MySqlCommand(funcionarioQuery, connection, transaction))
                            {
                                funcionarioCommand.Parameters.AddWithValue("@Nome", nome);
                                funcionarioCommand.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                                funcionarioCommand.Parameters.AddWithValue("@Cpf", cpf);
                                funcionarioCommand.Parameters.AddWithValue("@DataAdmissao", dataAdmissao);
                                funcionarioCommand.Parameters.AddWithValue("@Salario", salario);
                                funcionarioCommand.Parameters.AddWithValue("@Cargo", cargo);
                                funcionarioCommand.Parameters.AddWithValue("@ObservacaoSaude", observacaoSaude);
                                funcionarioCommand.Parameters.AddWithValue("@Ferias", ferias);

                                funcionarioCommand.ExecuteNonQuery();

                                // Recupera o ID do funcionário inserido
                                int funcionarioId = (int)funcionarioCommand.LastInsertedId;

                                // Insere o endereço na tabela `endereco`
                                string enderecoQuery = "INSERT INTO endereco (rua, numero, cidade, bairro, cep, complemento, funcionario_id) " +
                                                       "VALUES (@Rua, @Numero, @Cidade, @Bairro, @Cep, @Complemento, @FuncionarioId)";

                                using (var enderecoCommand = new MySqlCommand(enderecoQuery, connection, transaction))
                                {
                                    enderecoCommand.Parameters.AddWithValue("@Rua", rua);
                                    enderecoCommand.Parameters.AddWithValue("@Numero", numero);
                                    enderecoCommand.Parameters.AddWithValue("@Cidade", cidade);
                                    enderecoCommand.Parameters.AddWithValue("@Bairro", bairro);
                                    enderecoCommand.Parameters.AddWithValue("@Cep", cep);
                                    enderecoCommand.Parameters.AddWithValue("@Complemento", complemento);
                                    enderecoCommand.Parameters.AddWithValue("@FuncionarioId", funcionarioId);

                                    enderecoCommand.ExecuteNonQuery();
                                }
                            }

                            // Confirma a transação
                            transaction.Commit();
                            MessageBox.Show("Funcionário e endereço cadastrados com sucesso!", "Sucesso");
                        }
                        catch (Exception ex)
                        {
                            // Em caso de erro, desfaz a transação
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao cadastrar: {ex.Message}", "Erro");
                        }
                    }
                }
            }
        }
    }
}