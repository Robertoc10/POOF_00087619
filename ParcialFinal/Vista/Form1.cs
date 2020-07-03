using System;
using System.Windows.Forms;
using ParcialFinal.Controlador;
using ParcialFinal.Modelo;

namespace ParcialFinal.Vista
{
    public partial class Form1 : Form
    {
        private User usuario;
        public Form1(User u)
        {
            InitializeComponent();
            usuario = u;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            switch (usuario.idDepartamento)
            {
                case 1:
                    tabPage2.Parent = null;
                    tabPage3.Parent = null;
                    tabPage4.Parent = null;
                    tabPage5.Parent = null;
                    tabPage6.Parent = null;
                    tabPage7.Parent = null;
                    
                    break;
                case 2:
                
                tabPage1.Parent = null;
                tabPage3.Parent = null;
                tabPage4.Parent = null;
                tabPage6.Parent = null;
                tabPage7.Parent = null;
                    break;
                case 3:
                    tabPage1.Parent = null;
                    tabPage2.Parent = null;
                    break;
            }

            actualizarControles();
            
        }

        public void actualizarControles()
        
        {

            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = RegisterData.RegPersonal(usuario.idUsuario);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = RegisterData.RegGeneral();
            dataGridView3.DataSource = null;
            string sql =
                "SELECT sc.idUsuario, sc.entradas FROM (SELECT u.idUsuario, count(r.idUsuario) as entradas FROM REGISTRO r, USUARIO u WHERE r.idUsuario = u.idUsuario GROUP BY u.idUsuario) AS sc WHERE sc.entradas % 2 !=0";
           var dt = DBConnection.ExecuteQuery(sql);
            dataGridView3.DataSource = dt;
            dataGridView4.DataSource = null;
            string sql1 =
                "SELECT d.nombre, count(u.idDepartamento) as frecuencia FROM REGISTRO r, DEPARTAMENTO d, USUARIO u WHERE r.idUsuario = u.idUsuario AND d.idDepartamento = u.idDepartamento GROUP BY d.idDepartamento ORDER BY frecuencia DESC LIMIT 1;";
            var ds = DBConnection.ExecuteQuery(sql1);
            dataGridView4.DataSource = ds;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterData.NuevoRegistro(Convert.ToInt32(txt1.Text),radioButton1.Checked, txtTemp.Text );
            MessageBox.Show("¡Registrado!", 
                "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarControles();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserData.crearNuevo(Convert.ToInt32(txtId.Text), txtContra.Text, txtNombre.Text, 
                txtApellido.Text, txtDui.Text, txtFecha.Text  );
            MessageBox.Show("¡Nuevo usuario agregado!", 
                "Agregar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarControles();
        }

        private void btnDeleteUsu_Click(object sender, EventArgs e)
        {
            UserData.eliminar(Convert.ToInt32(txtUsuEliminar.Text));
            MessageBox.Show("¡Usuario Eliminado!", 
                "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            actualizarControles();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir, " + usuario.nombre + "?", 
                "Salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                            
                    e.Cancel = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ha sucedido un error, favor intente dentro de un minuto.", 
                        "Salir?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}