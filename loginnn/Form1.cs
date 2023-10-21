using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace loginnn
{
    public partial class Form1 : Form
    {
        SqlConnection conex = new SqlConnection("server=localhost\\SQLEXPRESS;database=db_usuario; integrated security=true");
        int intentosFallidos = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btniniciar_Click(object sender, EventArgs e)
        {
            conex.Open();
            string consulta = "select * from registro where usuario='" + txtusuario.Text + "' and contraseña='" + txtcontraseña.Text + "'";
            SqlCommand comando = new SqlCommand(consulta, conex);
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (string.IsNullOrEmpty(txtusuario.Text) || string.IsNullOrEmpty(txtcontraseña.Text))
            {
                MessageBox.Show("Por favor ingrese nombre de usuario y contraseña", "Error");
            }
            else
            {
                if (lector.HasRows)
                {
                    MessageBox.Show("Bienvenido");
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    intentosFallidos++;
                    MessageBox.Show("Nombre de usuario o contraseña incorrecto. Intentos fallidos: " + intentosFallidos);

                    if (intentosFallidos >= 3)
                    {
                        MessageBox.Show("Tres intentos fallidos. Cerrando la aplicación.");
                        Application.Exit();
                    }
                }
            }

            conex.Close();

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
//CREATE DATABASE db_usuario 
//use db_usuario 

//CREATE TABLE registro
//(usuario NVARCHAR(50) NOT NULL,
//contraseña NVARCHAR(50) NOT NULL)
//insert into registro values( 'lana2816', '1234')
//insert into registro values( 'jan18', '1234')