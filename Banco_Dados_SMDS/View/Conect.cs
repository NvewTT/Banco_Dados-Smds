using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco_Dados_SMDS.View
{
    public partial class Conect : Form
    {
        MySqlConect cnn = new MySqlConect();
        public Conect()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                cnn.OpenConection();
                MessageBox.Show("Conection Open!!");
                DialogResult = DialogResult.OK;
                cnn.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Conection Fail");
            }
        }
    }
}
