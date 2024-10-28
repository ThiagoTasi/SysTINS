using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysTINSApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // colocar a validação do login
            var usuario = Usuarío.EfetuarLogin (txtEmail.Text, txtSenha.Text);
            if(usuario.Id>0)
            {
                Close();
            }
            else
            {
                lblMensagem.Text = "Usuarioe/ou senha inválida";
            }

            
        }
    }
}
