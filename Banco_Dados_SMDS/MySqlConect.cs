using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Banco_Dados_SMDS
{
    class MySqlConect
    {
        string connetionString;
        MySqlConnection cnn;
        public void OpenConection()
        {
            
            this.connetionString = @"Data Source=localhost;Initial Catalog=ultra_vnc;User ID=root;Password=";

            this.cnn = new MySqlConnection(connetionString);

            this.cnn.Open();
        }

        public void CloseConnection()
        {
            this.cnn.Close();
        }

        public void ExecuteQueries(string Query_)
        {
            MySqlCommand cmd = new MySqlCommand(Query_, this.cnn);
            cmd.ExecuteNonQuery();
        }

        public object ShowDataInGridView(string Query_)
        {
            MySqlDataAdapter dr = new MySqlDataAdapter(Query_, this.connetionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

    }
}
