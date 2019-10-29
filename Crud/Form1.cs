using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud
{
    public partial class Form1 : Form
    {
        pro_chefeEntities bd = new pro_chefeEntities();
        Banco bancoSelecionado;

        public Form1()
        {
            InitializeComponent();
            Listar();
        }

        private void Listar()
        {
            Banco lista = new Banco();
            dataGridView1.DataSource = bd.Banco.ToList();
        }

        private void cadastrar()
        {
            Banco banco = new Banco();
            {
                banco.matricula = Convert.ToInt32(textBox1.Text);
                banco.nome = textBox2.Text;
                banco.cargo = textBox3.Text;
            }
            bd.Banco.Add(banco);
            bd.SaveChanges();
            MessageBox.Show("Usúario Cadastrado com Sucesso");
            Listar();
        }

        private void editar()
        {
            //bancoSelecionado = bd.Banco.Find(dataGridView1.SelectedRows[0].Cells)

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());

            if (id > 0)
            {
                bancoSelecionado = bd.Banco.Find(id);
                bancoSelecionado.matricula = Convert.ToInt32(textBox1.Text);
                bancoSelecionado.nome = textBox2.Text;
                bancoSelecionado.cargo = textBox3.Text;
                bd.SaveChanges();
                MessageBox.Show("Banco Alterado com Sucesso");
                Listar();

            } else
            {
                MessageBox.Show("Selecione o banco que voce quer alterar");
            }

        }
        
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            cadastrar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void BtnApagar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());

            if (id > 0)
            {
                bancoSelecionado = bd.Banco.Find(id);
                bd.Banco.Remove(bancoSelecionado);
                bd.SaveChanges();
                MessageBox.Show("Banco Excluido");
                Listar();

            }
            else
            {
                MessageBox.Show("Selecione o banco que voce quer apagar");
            }
        }
    }
}
