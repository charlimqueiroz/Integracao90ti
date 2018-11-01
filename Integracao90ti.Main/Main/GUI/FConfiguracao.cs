using Integracao90ti.Persistencia.ConfiguracaoServidor;
using System;
using System.Windows.Forms;
using static Integracao90ti.Comum.Enum.Enum;

namespace Integracao90ti.Main.GUI
{
    public partial class FConfiguracao : Form
    {
        private ConfiguracaoServidor configuracaoServidor = new ConfiguracaoServidor();

        public FConfiguracao()
        {
            InitializeComponent();

            cbDialeto.DataSource = Enum.GetValues(typeof(Dialect));
            CarregarAbaConfiguracoes();
        }

        private void CarregarAbaConfiguracoes()
        {
            var repConfig = configuracaoServidor.GetConfiguracao().Repositorio;

            cbDialeto.SelectedItem = Enum.Parse(typeof(Dialect), repConfig.Dialect.ToUpper());
            tbBaseDeDados.Text = repConfig.Database;
            tbSenha.Text = repConfig.PWD;
            tbServidor.Text = repConfig.Server;
            tbUsuario.Text = repConfig.User;
        }

        private void GravarConnectionString()
        {
            var repConfig = configuracaoServidor.GetConfiguracao().Repositorio;
            configuracaoServidor.GetConfiguracao().SessaoUsuario.TempoInatividade = 2000;
            repConfig.Dialect = cbDialeto.Text;
            repConfig.Database = tbBaseDeDados.Text;
            repConfig.PWD = tbSenha.Text;
            repConfig.Server = tbServidor.Text;
            repConfig.User = tbUsuario.Text;

            configuracaoServidor.Salvar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tbServidor.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Informe o servidor");
                tbServidor.Focus();
            }
            else if (tbBaseDeDados.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Informe a base de dados");
                tbBaseDeDados.Focus();
            }
            else if (tbUsuario.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Informe o usuário");
                tbUsuario.Focus();
            }
            else if (tbSenha.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Informe a senha");
                tbSenha.Focus();
            }
            else
                GravarConnectionString();
        }
    }
}
