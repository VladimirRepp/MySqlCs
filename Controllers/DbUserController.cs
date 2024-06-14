using LanguageTraining.Models;
using MySql.Data.MySqlClient;
using System;

namespace LanguageTraining.Context
{
    public class DbUserController : DbBaseController<User>
    {
        private static User _savedUser;
        public User SavedUser
        {
            get => _savedUser;
            set => _savedUser = value;
        }

        public DbUserController() {
            _tableName = "User";
        }

        public bool Request_TrySelectByLoginAndPassword(string log, string pass)
        {
            MySqlDataReader mySqlDataReader = null;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(
                    $"SELECT * FROM `{_tableName}` WHERE Login = @log AND Password = @pass", 
                    _dbConnector.GetConnection);
                mySqlCommand.Parameters.AddWithValue("@log", log);
                mySqlCommand.Parameters.AddWithValue("@pass", pass);

                _dbConnector.OpenConnection();
                mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        _savedUser = new User();
                        _savedUser.SetData(ref mySqlDataReader);
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

            return _savedUser != null;
        }
    }
}
