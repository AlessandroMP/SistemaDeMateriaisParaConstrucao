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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        Clientes novoCliente;
        
        private void RbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPessoaFisica.Checked == true)
            {
                gbDocumentosPessoaFisica.Visible = true;
                gbDocumentosPessoaJuridica.Visible = false;
            }
        }

        private void RbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPessoaJuridica.Checked == true)
            {
                gbDocumentosPessoaJuridica.Visible = true;
                gbDocumentosPessoaFisica.Visible = false;               
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                novoCliente = new Clientes();
                if (rbPessoaFisica.Checked == true)
                {
                    novoCliente.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text, txtCidade.Text, txtEstado.Text, txtTelefone1.Text,
                                       txtTelefone2.Text, txtEmail.Text, dtpDataCadastro.Value.Date, dtpNascimento.Value.Date, txtObservacao.Text);

                    DataTable dadosTabela = new DataTable();
                    novoCliente = new Clientes();
                    dadosTabela = novoCliente.Listar();

                    novoCliente = new Clientes();
                    novoCliente.SalvarPessoaFísica(Convert.ToInt32(dadosTabela.Rows[0]["ID_CLIENTE"]), txtCpf.Text, txtRg.Text);
                    MessageBox.Show("Cliente Cadastrado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    novoCliente.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text, txtCidade.Text,
                                       txtEstado.Text, txtTelefone1.Text, txtTelefone2.Text, txtEmail.Text, dtpDataCadastro.Value.Date,
                                       dtpNascimento.Value.Date, txtObservacao.Text);

                    DataTable dadosTabela = new DataTable();
                    novoCliente = new Clientes();
                    dadosTabela = novoCliente.Listar();

                    novoCliente = new Clientes();
                    novoCliente.SalvarPessoaJuridica(Convert.ToInt32(dadosTabela.Rows[0]["ID_CLIENTE"]), txtCnpj.Text, txtIe.Text);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
