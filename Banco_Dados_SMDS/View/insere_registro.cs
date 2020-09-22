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
    public partial class insere_registro : Form
    {
        MySqlConect cnn = new MySqlConect();
        ErrorProvider ErrorProvider1 = new ErrorProvider();
        ErrorProvider ErrorProvider2 = new ErrorProvider();
        ErrorProvider ErrorProvider3 = new ErrorProvider();
        ErrorProvider ErrorProvider4 = new ErrorProvider();
        ErrorProvider ErrorProvider5 = new ErrorProvider();
        ErrorProvider ErrorProvider6 = new ErrorProvider();
        ErrorProvider ErrorProvider7 = new ErrorProvider();
        ErrorProvider ErrorProvider8 = new ErrorProvider();
        ErrorProvider ErrorProvider9 = new ErrorProvider();

        public insere_registro()
        {
            InitializeComponent();
        }

        private void insere_registro_Load(object sender, EventArgs e)
        {

        }

        private void btn_Inserir_Click(object sender, EventArgs e)
        {
            if (IsDataValid())
            {
                try
                {
                    cnn.OpenConection();
                    cnn.ExecuteQueries("INSERT INTO `smds`(`SO`, `USUARIO_PC`, `IP`, `NOME_PC`, `USUARIO_REMOTO`, `Local`, `PATRIMONIO`, `MIKROTIK`, `ULTRAVNC`) VALUES ('" + SO.Text + "','" +
                        USUARIO_PC.Text + "','" + IP.Text + "','" + NOME_PC.Text + "','" + USUARIO_REMOTO.Text + "','" + Local.Text + "','" + PATRIMONIO.Text + "','" + MIKROTIK.Text + "','" +
                        ULTRAVNC.Text + "')");
                    MessageBox.Show("Dado Inserido com sucesso!!");
                    SO.Clear();
                    USUARIO_PC.Clear();
                    IP.Clear();
                    NOME_PC.Clear();
                    USUARIO_REMOTO.Clear();
                    Local.Clear();
                    PATRIMONIO.Clear();
                    MIKROTIK.Clear();
                    ULTRAVNC.Clear();
                }
                catch
                {
                    MessageBox.Show("Error!");
                }



            }
            else
            {
                MessageBox.Show("error!");
            }
        }


        private bool IsDataValid()

        {
            string error = "Preencha o campo!";

            bool resposta = true;

            if (string.IsNullOrEmpty(SO.Text))

            {

                ErrorProvider1.SetError(SO, error);

                resposta = false;



            }
            else
            {
                ErrorProvider1.Clear();
            }
            if (string.IsNullOrEmpty(USUARIO_PC.Text))

            {

                ErrorProvider2.SetError(USUARIO_PC, error);

                resposta = false;


                


            }
            else
            {
                ErrorProvider2.Clear();
            }
            if (string.IsNullOrEmpty(IP.Text))

            {

                ErrorProvider3.SetError(IP, error);

                resposta = false;


               


            }
            else
            {
                ErrorProvider3.Clear();
            }
            if (string.IsNullOrEmpty(NOME_PC.Text))

            {

                ErrorProvider4.SetError(NOME_PC, error);

                resposta = false;


                


            }
            else
            {
                ErrorProvider4.Clear();
            }
            if (string.IsNullOrEmpty(USUARIO_REMOTO.Text))

            {

                ErrorProvider5.SetError(USUARIO_REMOTO, error);

                resposta = false;




            }
            else
            {
                ErrorProvider5.Clear();
            }
            if (string.IsNullOrEmpty(Local.Text))

            {

                ErrorProvider6.SetError(Local, error);

                resposta = false;


                


            }
            else
            {
                ErrorProvider6.Clear();
            }
            if (string.IsNullOrEmpty(PATRIMONIO.Text))

            {

                ErrorProvider7.SetError(PATRIMONIO, error);

                resposta = false;


                


            }
            else
            {
                ErrorProvider7.Clear();
            }
            if (string.IsNullOrEmpty(MIKROTIK.Text))

            {

                ErrorProvider8.SetError(MIKROTIK, error);

                resposta = false;


                


            }
            else
            {
                ErrorProvider8.Clear();
            }
            if (string.IsNullOrEmpty(ULTRAVNC.Text))

            {

                ErrorProvider9.SetError(ULTRAVNC, error);

                resposta = false;


                


            }
            else
            {
                ErrorProvider9.Clear();
            }


            return resposta;
        } 
    }
}
