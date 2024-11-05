using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Controle_de_funcionarios
{
    public class LoginForm : Form
    {
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label messageLabel;

        public LoginForm()
        {
            this.Text = "Login";
            this.Width = 400;
            this.Height = 250;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            usernameLabel = new Label
            {
                Text = "Nome de Usuário:",
                AutoSize = true,
                Location = new Point(50, 30)
            };
            usernameTextBox = new TextBox
            {
                Width = 200,
                Location = new Point(150, 25)
            };

            passwordLabel = new Label
            {
                Text = "Senha:",
                AutoSize = true,
                Location = new Point(50, 80)
            };
            passwordTextBox = new TextBox
            {
                Width = 200,
                Location = new Point(150, 75),
                PasswordChar = '*'
            };

            loginButton = new Button
            {
                Text = "Login",
                Width = 100,
                Location = new Point(150, 130),
                BackColor = Color.FromArgb(100, 149, 237),
                ForeColor = Color.White
            };
            loginButton.Click += LoginButton_Click;

            messageLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                Location = new Point(50, 170)
            };

            this.Controls.Add(usernameLabel);
            this.Controls.Add(usernameTextBox);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(passwordTextBox);
            this.Controls.Add(loginButton);
            this.Controls.Add(messageLabel);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Verifica as credenciais no banco de dados
            using (var db = new DatabaseConnection())
            {
                using (var connection = db.GetConnection())
                {
                    if (connection != null)
                    {
                        string query = "SELECT COUNT(*) FROM usuarios WHERE nome_usuario = @username AND senha = @password";
                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);

                            int result = Convert.ToInt32(command.ExecuteScalar());
                            if (result > 0)
                            {
                                messageLabel.Text = "Login bem-sucedido!";
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                messageLabel.Text = "Nome de usuário ou senha incorretos.";
                            }
                        }
                    }
                    else
                    {
                        messageLabel.Text = "Erro na conexão com o banco de dados.";
                    }
                }
            }
        }
    }
}
