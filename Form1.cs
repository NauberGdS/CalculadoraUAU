using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
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
        private bool numeroClicado = false;
        private bool operadorClicado = false;

        public Form1()
        {
            InitializeComponent();
        }

        //selecionando botões de operação
        private void Operador_Click(object sender, EventArgs e)
        {
            //correção erro caso o primeiro caracter seja um operador;
            if (numeroClicado && !operadorClicado)
            { 
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
            operato = botao.Text.ToString();
            operadorClicado = true; // recebe true para não haver duplicidade
            }
            else
            {
                MessageBox.Show("Selecione os números!");
            }
        }

        //selecionando botões numéricos
        private void Numero_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
            ultimonum = int.Parse(botao.Text);
            numeroClicado = true;
            operadorClicado = false;
        }

        //botão apagar, quando chamado exclui dados da tela
        private void btnApagar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
            txbAux.Clear();
            numeroClicado = false;
        }

        //botão igual 
        private void btnIgual_Click(object sender, EventArgs e)
        {
                if (ultimonum == 0 && operato == "/")
                {
                    MessageBox.Show("Impossível dividir por zero!");
                    //chamar a classse apagar, para que o erro do operador antes do numero não ocorra
                    btnApagar_Click(sender, e);
            }
                else
                {
                    var v = dt.Compute(txbTela.Text, "");
                    txbAux.Text = txbTela.Text;
                    txbTela.Text = v.ToString();
                operadorClicado = false; // operadorClicado volta a ser falso para não haver duplicidade nos operadores
                }
            
        }

    }
}
