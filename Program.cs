using System;
using System.Drawing;
using System.Windows.Forms;

namespace Controle_de_funcionarios
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MeuFormulario());
        }
    }

    public class MeuFormulario : Form
    {
        private Button meuBotao;
        private Label meuLabel;
        private Label nomeLabel, nascimentoLabel, cpfLabel, admissaoLabel, salarioLabel, cargoLabel, saudeLabel, feriasLabel;
        private TextBox nomeTextBox, cpfTextBox, salarioTextBox, cargoTextBox, saudeTextBox, feriasTextBox;
        private DateTimePicker nascimentoPicker, admissaoPicker;

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
            // Captura e exibe os dados preenchidos
            string dadosFuncionario = $"Nome: {nomeTextBox.Text}\n" +
                                      $"Data de Nascimento: {nascimentoPicker.Value.ToShortDateString()}\n" +
                                      $"CPF: {cpfTextBox.Text}\n" +
                                      $"Data de Admissão: {admissaoPicker.Value.ToShortDateString()}\n" +
                                      $"Salário: {salarioTextBox.Text}\n" +
                                      $"Cargo: {cargoTextBox.Text}\n" +
                                      $"Observação de Saúde: {saudeTextBox.Text}\n" +
                                      $"Férias: {feriasTextBox.Text}\n";
    

            MessageBox.Show(dadosFuncionario, "Dados do Funcionário");
        }
    }
}
