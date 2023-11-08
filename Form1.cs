using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraUAU
{
    public partial class Form1 : Form
    {
        //declarando variaveis universais:
        DataTable dt = new DataTable();
        string operato;
        int ultimonum;

        public Form1()
        {
            InitializeComponent();
        }

        //selecionando botões de operação
        private void Operador_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
            operato = botao.Text.ToString();
        }

        //selecionando botões numéricos
        private void Numero_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
            ultimonum = int.Parse(botao.Text);
        }

        //botão apagar, quando chamado exclui dados da tela
        private void btnApagar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
            txbAux.Clear();
        }

        //botão igual 
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (ultimonum == 0 && operato == "/")
            {
                MessageBox.Show("Impossível dividir por zero");
                txbTela.Clear();
                txbAux.Clear();
            }
            else
            {
                var v = dt.Compute(txbTela.Text, "");
                txbAux.Text = txbTela.Text;
                txbTela.Text = v.ToString();
            }

        }
    }
}
