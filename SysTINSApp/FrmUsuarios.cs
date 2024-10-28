using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysTINSClass;
using static Mysqlx.Notice.Warning.Types;

namespace SysTINSApp
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }




        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            //carregando o combobox de níveis
            cmbNivel.DataSource = Nível.ObterLista();
            cmbNivel.DisplayMember = "Nome";
            cmbNivel.ValueMember = "Id";

            CarregaGridUsuarios();
        }


        private void btnInser_Click(object sender, EventArgs e)
        {
            Usuario usuario = new(
                 txtNome.Text,
                 txtEmail.Text,
            txtSenha.Text,
                 Nível.ObterPorId(Convert.ToInt32(cmbNivel.SelectedValue))
                );
            usuario.Inserir();
            if (usuario.Id > 0)
            {
                CarregaGridUsuarios();
                MessageBox.Show($"Usuario {usuario.Id} Inserido com sucesso");
                btnInserir.Enabled = false;
            }
        }
        private void CarregaGridUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            //datagrid o datagrid de usuários
            dgvUsuarios.Rows.Clear();
            var listaDeUsuarios = Usuario.ObterLista();
            int linha = 0;
            foreach (var usuario in listaDeUsuarios)
            {
                dgvUsuarios.Rows.Add();
                dgvUsuarios.Rows[linha].Cells[0].Value = usuario.Id;
                dgvUsuarios.Rows[linha].Cells[1].Value = usuario.Nome;
                dgvUsuarios.Rows[linha].Cells[2].Value = usuario.Email;
                dgvUsuarios.Rows[linha].Cells[3].Value = usuario.Nível.Nome;
                dgvUsuarios.Rows[linha].Cells[4].Value = usuario.Ativo;
                linha++;

            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



