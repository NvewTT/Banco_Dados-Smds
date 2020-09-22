using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banco_Dados_SMDS.View;

namespace Banco_Dados_SMDS.View
{
    public partial class Principal : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        ErrorProvider errorProvider1 = new ErrorProvider();
        MySqlConect cnn = new MySqlConect();
        Boolean edit_forsql = false;
        private int row_index = -1;
        
        
        public Principal()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {

            try
            {
                cnn.OpenConection();
                dataGridView.DataSource = cnn.ShowDataInGridView("Select * From smds LIMIT 22");

                dataGridView.Columns["ID"].Visible = false;
            }
            catch
            {
                MessageBox.Show("error");
            }

            comboBox1.Items.Add((String)dataGridView.Columns[1].Name);
            comboBox1.Items.Add((String)dataGridView.Columns[2].Name);
            comboBox1.Items.Add((String)dataGridView.Columns[3].Name);
            comboBox1.Items.Add((String)dataGridView.Columns[4].Name);
            comboBox1.Items.Add((String)dataGridView.Columns[5].Name);
            comboBox1.Items.Add((String)dataGridView.Columns[6].Name);
            comboBox1.Items.Add((String)dataGridView.Columns[7].Name);
            comboBox1.Items.Add((String)dataGridView.Columns[8].Name);
            comboBox1.Items.Add((String)dataGridView.Columns[9].Name);

            
        }



        private void patrimonio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_insere_registro_Click(object sender, EventArgs e)
        {

            insere_registro insere = new insere_registro();
            insere.ShowDialog();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_filtrar_Click(object sender, EventArgs e)
        {

            try
            { if (!string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
                {
                    errorProvider.Clear();

                }

                if (string.IsNullOrEmpty(texto.Text))
                {
                    errorProvider1.SetError(texto, "Preencha o campo!");

                }
                else
                {
                    errorProvider1.Clear();
                }

                if (!string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) && !string.IsNullOrEmpty(texto.Text))
                {
                    dataGridView.DataSource = cnn.ShowDataInGridView("SELECT * FROM `smds` WHERE `" + comboBox1.SelectedItem.ToString() + "` like '" + texto.Text + "'");
                    
                }


            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("selecione um item para pesquisar");
                errorProvider.SetError(comboBox1, "Selecione um item!");
                if (string.IsNullOrEmpty(texto.Text))
                {
                    errorProvider1.SetError(texto, "Preencha o campo!");

                }
                else
                {
                    errorProvider1.Clear();
                }
                
            }
            this.row_index = -1;
        }

        private void texto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_filtrar_Click(sender, e);
            }
        }

        private void texto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(texto.Text.Trim()))
            {
                try
                {
                    dataGridView.DataSource = cnn.ShowDataInGridView("Select * From smds LIMIT 22");
                }
                catch
                {
                    MessageBox.Show("error");
                }

                this.row_index = -1;
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!edit_forsql)
            {

                DialogResult dialogResult = MessageBox.Show("Deseja mesmo atualizar o valor de " + dataGridView.Columns[e.ColumnIndex].Name.ToString(), "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString()))
                    {
                        dataGridView[e.ColumnIndex, e.RowIndex].ErrorText = "";

                        cnn.ExecuteQueries("UPDATE `smds` SET `" + dataGridView.Columns[e.ColumnIndex].Name.ToString() + "` = '" +
                            dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() + "' WHERE ID = " + dataGridView[0, e.RowIndex].Value.ToString());

                        MessageBox.Show(dataGridView.Columns[e.ColumnIndex].Name.ToString() + " Alterado com sucesso!");

                    }
                    else
                    {
                        MessageBox.Show("Coloque um valor valido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView[e.ColumnIndex, e.RowIndex].ErrorText = "Insira um Valor valido!";


                    }



                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    edit_forsql = true;
                    dataGridView.DataSource = cnn.ShowDataInGridView("Select * From smds LIMIT 22");
                    

                }
            }
            else {
                edit_forsql = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)

        {
            


            if (this.row_index > -1)
            {
                string porta;
                string ip = dataGridView[3, this.row_index].Value.ToString();
                if(dataGridView[1, this.row_index].Value.ToString() == "LINUX")
                {
                    porta = "5900";
                    
                }
                else
                {
                    porta = "4545";
                }
                string[] lines = { "[connection]",
"host=" + ip,
"port=" + porta,
"proxyhost=",
"proxyport=0",
"password=b86047e7024aab31",
"[options]",
"use_encoding_0=1",
"use_encoding_1=1",
"use_encoding_2=1",
"use_encoding_3=0",
"use_encoding_4=1",
"use_encoding_5=1",
"use_encoding_6=1",
"use_encoding_7=1",
"use_encoding_8=1",
"use_encoding_9=1",
"use_encoding_10=1",
"use_encoding_11=0",
"use_encoding_12=0",
"use_encoding_13=0",
"use_encoding_14=0",
"use_encoding_15=0",
"use_encoding_16=1",
"use_encoding_17=1",
"preferred_encoding=10",
"restricted=0",
"viewonly=0",
"nostatus=0",
"nohotkeys=0",
"showtoolbar=1",
"AutoScaling=0",
"fullscreen=0",
"SavePos=0",
"SaveSize=0",
"directx=0",
"autoDetect=0",
"8bit=0",
"shared=1",
"swapmouse=0",
"belldeiconify=0",
"emulate3=1",
"JapKeyboard=0",
"emulate3timeout=100",
"emulate3fuzz=4",
"disableclipboard=0",
"localcursor=1",
"Scaling=0",
"scale_num=1",
"scale_den=1",
"cursorshape=1",
"noremotecursor=0",
"compresslevel=6",
"quality=8",
"ServerScale=1",
"Reconnect=3",
"EnableCache=0",
"QuickOption=1",
"UseDSMPlugin=0",
"UseProxy=0",
"sponsor=0",
"selectedscreen=1",
"DSMPlugin=NoPlugin",
@"folder=C:\Users\gabriel\Documents\UltraVNC",
"prefix=vnc_",
"imageFormat=.jpeg",
"AutoReconnect=3",
"ExitCheck=0",
"FileTransferTimeout=30",
"ListenPort=5500",
"KeepAliveInterval=5",
"ThrottleMouse=0",
"AutoAcceptIncoming=0",
"AutoAcceptNoDSM=0",
"RequireEncryption=0",
"PreemptiveUpdates=0"};

                System.IO.File.WriteAllLines(@"C:\Users\gabriel\Desktop\ultra-vnc\WriteLines.vnc", lines);

                string strCmdText = @"/c C: & cd C:\Users\gabriel\Desktop\ultra-vnc & WriteLines.vnc";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = strCmdText;
                process.StartInfo = startInfo;
                process.Start();

            }
            else{
                MessageBox.Show("selecione uma linha");
            }
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.row_index = e.RowIndex;

        }

        private void dataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
    

