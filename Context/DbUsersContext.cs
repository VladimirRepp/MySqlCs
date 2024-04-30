using CargoTransportation.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoTransportation.Context
{
    public class DbUsersContext : DbBaseContext<MUser>
    {
        public DbUsersContext() {
            _tableName = "users";
        }

        public MUser? Query_SelectByLoginAndPassword(string log, string pass)
        {
            MySqlDataReader? mySqlDataReader = null;
            MUser? found = null;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM `{_tableName}` WHERE Login = @log AND Password = @pass", _dbConnector.GetConnection);
                mySqlCommand.Parameters.AddWithValue("@log", log);
                mySqlCommand.Parameters.AddWithValue("@pass", pass);

                _dbConnector.OpenConnection();
                mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        found = new MUser();
                        found.SetData(ref mySqlDataReader);
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mySqlDataReader?.Close();
                _dbConnector.CloseConnection();
            }

            return found;
        }

        public bool Query_TrySelectByLoginAndPassword(int id, out MUser? found)
        {
            found = Query_SelectById(id);
            return found != null;
        }
    }
}
