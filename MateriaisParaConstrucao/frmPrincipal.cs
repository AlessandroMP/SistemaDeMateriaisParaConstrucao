using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriaisParaConstrucao
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        //Evento click do btnFuncionarios em que o formulario frmFuncionarios é instanciado e exibido
        private void BtnFuncionarios_Click(object sender, EventArgs e)
        {
            frmFuncionarios funcionarios = new frmFuncionarios();
            funcionarios.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //Estabelece a conexão com o banco de dados através da classe Conexao e seu método stringConexao
            using (SqlConnection novaConexao = new SqlConnection(Conexao.StringConexao)) //Utilizando a conexao da lasse string conexao
            {
                try//Tenta realizar a as linhas de comandos dentro do bloco try
                {
                  novaConexao.Open();
                  MessageBox.Show("Conectou!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)//Se houver algum erro no bloco try, o programa captura o mesmo e realiza a ação entre chaves
                {

                    MessageBox.Show("Erro de Conexão!", "Desconectado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
                finally//Por fim ele realiza a ação informada entre chaves, com ou sem erro
                {
                    MessageBox.Show("Bem Vindo ao Sistema de Materiais para Construção!", " Materiais para Construção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            frmClientes Clientes = new frmClientes();
            Clientes.ShowDialog();
        }
    }
}
