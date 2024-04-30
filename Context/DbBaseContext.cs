using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TODO_Test.Models;
using TODO_Test.Database;
using MySql.Data.MySqlClient;

namespace TODO_Test.Context
{
    public class DbBaseContext<T> where T : IBaseData, new()
    {
        protected List<T> _data;
        protected string _tableName;
        protected DbConnector _dbConnector;

        public int Count => _data.Count;
        public T this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }
        public List<T> Data => _data;
        public string TableName => _tableName;

        public DbBaseContext()
        {
            _data = new List<T>();
            _tableName = "default";
            _dbConnector = new DbConnector();
        }

        protected bool UpdateById(T d)
        {
            int index = _data.FindIndex(x => x.Id == d.Id);

            if (index == -1)
                return false;

            _data[index] = d;
            return true;
        }

        protected bool RemoveAtId(int id)
        {
            return _data.RemoveAll(x => x.Id == id) == 1;
        }

        public int GetIndexById(int id)
        {
            return _data.FindIndex(x => x.Id == id);
        }

        public T GetById(int id)
        {
            return _data.Find(x => x.Id == id);
        }

        public bool TryGetById(int id, out T findemItem)
        {
            findemItem = _data.Find(x => x.Id == id);
            return findemItem != null;
        }

        public bool Query_SelectAll()
        {
            MySqlDataReader mySqlDataReader = null;
            _data.Clear();

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM `{_tableName}`", _dbConnector.GetConnection);

                _dbConnector.OpenConnection();
                mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        T d = new T();
                        d.SetData(ref mySqlDataReader);

                        _data.Add(d);
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

            return _data.Count > 0;
        }

        public T Query_SelectById(int id)
        {
            MySqlDataReader mySqlDataReader = null;
            T found = default;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM `{_tableName}` WHERE Id = @id", _dbConnector.GetConnection);
                mySqlCommand.Parameters.AddWithValue("@id", id);

                _dbConnector.OpenConnection();
                mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        found = new T();
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

        public bool Query_TrySelectById(int id, out T found)
        {
            found = Query_SelectById(id);
            return found != null;
        }

        public bool Query_Insert(T d) {
            bool isDone = false;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"INSERT INTO `{_tableName}` {d.ToParamsQuery_Insert}", 
                    _dbConnector.GetConnection);
                _dbConnector.OpenConnection();

                int i = 0;
                foreach(string s in d.ToArrayStr)
                {
                    mySqlCommand.Parameters.AddWithValue($"@param{i++}", s);
                }

                if(mySqlCommand.ExecuteNonQuery() == 1)
                {
                    isDone = true;
                    _data.Add(d);
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
                _dbConnector.CloseConnection();
            }

            return isDone;
        }

        public bool Query_Update(T d)
        {
            bool isDone = false;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"UPDATE `{_tableName}` SET {d.ToParamsQuery_Update} " +
                    $"WHERE Id = @id",
                    _dbConnector.GetConnection);
                _dbConnector.OpenConnection();

                int i = 0;
                mySqlCommand.Parameters.AddWithValue("@id", d.Id);
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

        public bool Query_Delete(int id)
        {
            bool isDone = false;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"DELETE FROM `{_tableName}` WHERE Id = @id LIMIT 1",
                    _dbConnector.GetConnection);
                _dbConnector.OpenConnection();

                mySqlCommand.Parameters.AddWithValue("@id", id);

                if (mySqlCommand.ExecuteNonQuery() == 1)
                    isDone = RemoveAtId(id); 
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

        public bool Query_ClearTable()
        {
            bool isDone = false;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"TRUNCATE TABLE `{_tableName}`",
                    _dbConnector.GetConnection);
                _dbConnector.OpenConnection();

                mySqlCommand.ExecuteNonQuery();
                _data.Clear();
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

        public int Query_GetLastId()
        {
            MySqlDataReader mySqlDataReader = null;
            int id = -1;

            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand($"SELECT MAX(Id) AS Id FROM `{_tableName}`",
                    _dbConnector.GetConnection);
                _dbConnector.OpenConnection();

                mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        id = Convert.ToInt32(mySqlDataReader["Id"]);
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

            return id;
        }
    }
}
