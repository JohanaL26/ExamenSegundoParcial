
using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Windows.Forms;

namespace SegundoExamen
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {

            //VALIDAR CON UN ERRORPROVIDER PARA QUE NO PASE AL SIGUIENTE SIN ANTES LLENAR EL CAMPO
            if (string.IsNullOrEmpty(UsuarioTextBox.Text))
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese el Id del usuario");
                UsuarioTextBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ClaveTextBox.Text))
            {
                errorProvider1.SetError(ClaveTextBox, "Ingrese la clave del usuario");
                ClaveTextBox.Focus();
                return;
            }


            UsuarioAccs usuarioAccs = new UsuarioAccs();
            Usuario usuario = new Usuario();

            usuario = usuarioAccs.Login(UsuarioTextBox.Text, ClaveTextBox.Text);

            //SENTENCIA PARA CUANDO SE INGRESEN DATOS INCORRECTOS
            if (usuario == null)
            {
                MessageBox.Show("DATOS ERRONEOS");
                return;
            }

            MessageBox.Show("DATOS CORRECTOS");

            //CAREACION DE OBJETO PARA PASAR AL SIGUIENTE FORMULARIO
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();



        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            //CERRAR EL FORMULARIO
            this.Close();
        }
    }
}
