using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova_banco_de_Dados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Conexão conn = new Conexão();
        string sql = null;

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            sql = "delete from tb_cliente where cli_cpf=' " + txtCpf + "'";
            if (conn.ComandoSql(sql))
            {
                MessageBox.Show("Excluido com sucesso");
            }else
            {
                MessageBox.Show("Não foi possível excluir");
            }
             

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            sql = "Update tb_cliente set cli_nome='"+ txtNome.Text+ "' , cli_celular='" + txtCelular.Text + "' , cli_email='" +txtEmail.Text + "' , cli_endereco='" + txtEndereco.Text + "' where cli_cpf='" + txtCpf.Text + "'";
            if (conn.ComandoSql(sql))
            {
                MessageBox.Show("atualizado");
            }
            else
            {
                MessageBox.Show("não foi possivel atualizar");
            }
            limpar();
            

        }
        private void limpar()
        {
            txtCpf.Text = null;
            txtNome.Text = null;
            txtCelular.Text = null;
            txtEmail.Text = null;
            txtEndereco.Text = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            sql = "insert into tb_cliente values('" + txtCpf.Text + "', '" + txtNome.Text + "', '" + txtCelular + "', '" + txtEmail + "', '" + txtEndereco + "')";
            if (conn.ComandoSql(sql))
            {
                MessageBox.Show("Cadastrado");
            }
            else
            {
                MessageBox.Show("não foi possivel cadastrar ");
            }
            limpar();
            

        }
       
    }
}
