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

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text == "0" && txtNome.Text == "Empty")
                {                  
                    MessageBox.Show("Por favor Preencha os dados do novo Funcionario", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Funcionarios novoFuncionario = new Funcionarios();
                    novoFuncionario.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, mtbCep.Text, txtCidade.Text, txtEmail.Text,
                                            dtpNascimento.Value.Date, mtTelefone1.Text, mtTelefone2.Text, txtRg.Text, mkCpf.Text, txtObservacoes.Text,
                                            dtpDataCadastro.Value.Date);
                    MessageBox.Show("Funcionario salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }      
    }
}
