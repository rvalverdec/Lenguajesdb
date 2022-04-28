using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectLenguajes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection conexion = new OracleConnection("DATA SOURCE=ORCL; PASSWORD=admin123; USER ID= admin");
            conexion.Open();

            OracleCommand comando = new OracleCommand("PKG_CONTA.Reporte_factura", conexion);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();

            adaptador.SelectCommand = comando;

            DataTable tabla = new DataTable();

            adaptador.Fill(tabla);

            dataGridView1.DataSource = tabla;

            conexion.Close();

            


        }

        private void button2_Click(object sender, EventArgs e)
        {

            OracleConnection conexion = new OracleConnection("DATA SOURCE=ORCL; PASSWORD=admin123; USER ID= admin");
            conexion.Open();

            String texto = textBox1.Text;

            OracleCommand comando = new OracleCommand("PKG_CONTA.TOTAL_MAESTRO( :texto)", conexion);

       

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.Add("filas", OracleType.Cursor).Direction = ParameterDirection.Output;

            MessageBox.Show("listo");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
