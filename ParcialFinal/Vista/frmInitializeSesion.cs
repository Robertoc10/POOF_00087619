using System;
using System.Windows.Forms;
using ParcialFinal.Controlador;
using ParcialFinal.Modelo;

namespace ParcialFinal.Vista
{
    public partial class frmInitializeSesion : Form
    {
        public frmInitializeSesion()
        {
            InitializeComponent();
        }


        private void frmInitializeSesion_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            comboBox1.ValueMember = "contrasenia";
            comboBox1.DisplayMember = "idUsuario";
            comboBox1.DataSource = UserData.getListaUsu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(comboBox1.SelectedValue.ToString()))
            {
                User u = (User) comboBox1.SelectedItem;
                MessageBox.Show("¡Bienvenido!", 
                    "Inicio sesion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                Form1 ventana = new Form1(u);
                ventana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("¡Contraseña incorrecta!", 
                    "Inicio sesion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}