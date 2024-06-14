// Необходимо установить MySQL Connectot .Net
// https://dev.mysql.com/downloads/connector/net/
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTraining.Database
{
    public class DbConnector
    {
        private MySqlConnection _mySqlConnection = new MySqlConnection(
            "server = localhost;" +
            "port = 3306;" +
            "username = root;" +
            "password = ;" +
            "database = 453_db;" +
            "SslMode = none"
            );

        public MySqlConnection GetConnection => _mySqlConnection;

        public void OpenConnection()
        {
            if (_mySqlConnection.State == System.Data.ConnectionState.Closed)
                _mySqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (_mySqlConnection.State == System.Data.ConnectionState.Open)
                _mySqlConnection.Close();
        }
    }
}
