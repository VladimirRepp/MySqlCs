using LanguageTraining.Context;
using LanguageTraining.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTraining.Controllers
{
    public class DbResultController : DbBaseController<Result>
    {
        public DbResultController() { 
            _tableName = "Result";
        }

        public bool Requst_TrySelectByIdUser(int idUser, out Result found)
        {
            MySqlDataReader mySqlDataReader = null;
            found = null;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(
                    $"SELECT * FROM `{_tableName}` WHERE IdUser = @id",
                    _dbConnector.GetConnection);
                mySqlCommand.Parameters.AddWithValue("@id", idUser);

                _dbConnector.OpenConnection();
                mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        found = new Result();
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

            return found != null;
        }

        public bool Requst_UpdatinByIdUser(Result d)
        {
            bool isDone = false;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"UPDATE `{_tableName}` SET {d.ToParamsUpdateRequest} " +
                    $"WHERE IdUser = @id",
                    _dbConnector.GetConnection);
                _dbConnector.OpenConnection();

                int i = 0;
                mySqlCommand.Parameters.AddWithValue("@id", d.IdUser);
                foreach (string s in d.ToArrayStr)
                {
                    mySqlCommand.Parameters.AddWithValue($"@param{i++}", s);
                }

                if (mySqlCommand.ExecuteNonQuery() == 1)
                    isDone = UpdateById(d);
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
                _dbConnector.CloseConnection();
            }

            return isDone;
        }
    }
}
