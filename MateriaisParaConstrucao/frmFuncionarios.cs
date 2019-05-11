using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriaisParaConstrucao
{
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
        }

        Funcionarios novoFuncionario;

        private void BtnSalvar_Click(object sender, EventArgs e)
        {            
            try
            {
                novoFuncionario = new Funcionarios();

                if (txtCodigo.Text == "0")
                {
                    novoFuncionario.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, mkCep.Text, txtCidade.Text, txtEmail.Text,
                                            dtpNascimento.Value.Date, mkTelefone1.Text, mkTelefone2.Text, txtRg.Text, mkCpf.Text, txtObservacoes.Text,
                                            dtpDataCadastro.Value.Date);
                    MessageBox.Show("Funcionario salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   novoFuncionario.Alterar(Convert.ToInt32(txtCodigo.Text), txtNome.Text, txtEndereco.Text, txtBairro.Text, mkCep.Text, txtCidade.Text, txtEmail.Text,
                                            dtpNascimento.Value.Date, mkTelefone1.Text, mkTelefone2.Text, txtRg.Text, mkCpf.Text, txtObservacoes.Text,
                                            dtpDataCadastro.Value.Date);
                    MessageBox.Show("Funcionario Alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }

                ListarFuncionarios();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Método responsável por limpar os componentes do formulário.
        private void Limpar()
        {
            txtCodigo.Text = "0";
            txtNome.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            mkCep.Clear();
            txtCidade.Clear();
            txtEmail.Clear();
            dtpNascimento.Value = DateTime.Today;
            txtObservacoes.Clear();
            txtRg.Clear();
            mkCpf.Clear();
            mkTelefone1.Clear();
            mkTelefone2.Clear();
        }

        private void Estilo()
        {
            for (int i = 0; i < dtgFuncionario.Rows.Count; i += 2)
            {
                dtgFuncionario.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void ListarFuncionarios()
        {
            novoFuncionario = new Funcionarios();
            dtgFuncionario.DataSource = novoFuncionario.Listar();
            Estilo(); 
        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            //Assim que carregar o formulário, os registros dos Funcionários serão mostrados n DataGridView.
            ListarFuncionarios();
        }

        //Carrega a áea de cadastro com os dados da linha selecionada na DataGridView
        private void DtgFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verifica o nome da coluna que recebeu o click.
            if (e.RowIndex >= 0)
            {
                if (dtgFuncionario.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    //Atribui a todos os campos o conteúdo das respectivas colunas, referentes a linha selecionada.
                    txtCodigo.Text = dtgFuncionario.Rows[e.RowIndex].Cells["ID_FUNCIONARIO"].Value.ToString();
                    txtNome.Text = dtgFuncionario.Rows[e.RowIndex].Cells["NOME_FUNCIONARIO"].Value.ToString();
                    txtEndereco.Text = dtgFuncionario.Rows[e.RowIndex].Cells["ENDERECO_FUNCIONARIO"].Value.ToString();
                    txtBairro.Text = dtgFuncionario.Rows[e.RowIndex].Cells["BAIRRO_FUNCIONARIO"].Value.ToString();
                    mkCep.Text = dtgFuncionario.Rows[e.RowIndex].Cells["CEP_FUNCIONARIO"].Value.ToString();
                    txtCidade.Text = dtgFuncionario.Rows[e.RowIndex].Cells["CIDADE_FUNCIONARIO"].Value.ToString();
                    txtEmail.Text = dtgFuncionario.Rows[e.RowIndex].Cells["EMAIL_FUNCIONARIO"].Value.ToString();
                    dtpNascimento.Value = Convert.ToDateTime(dtgFuncionario.Rows[e.RowIndex].Cells["NASCIMENTO_FUNCIONARIO"].Value.ToString());
                    mkTelefone1.Text = dtgFuncionario.Rows[e.RowIndex].Cells["TELEFONE1_FUNCIONARIO"].Value.ToString();
                    mkTelefone2.Text = dtgFuncionario.Rows[e.RowIndex].Cells["TELEFONE2_FUNCIONARIO"].Value.ToString();
                    txtRg.Text = dtgFuncionario.Rows[e.RowIndex].Cells["RG_FUNCIONARIO"].Value.ToString();
                    mkCpf.Text = dtgFuncionario.Rows[e.RowIndex].Cells["CPF_FUNCIONARIO"].Value.ToString();
                    dtpDataCadastro.Value = Convert.ToDateTime(dtgFuncionario.Rows[e.RowIndex].Cells["DATA_CADASTRO_FUNCIONARIO"].Value.ToString());
                    txtObservacoes.Text = dtgFuncionario.Rows[e.RowIndex].Cells["OBSERVACOES_FUNCIONARIO"].Value.ToString();
                }
            }
           
        }
    }

}  