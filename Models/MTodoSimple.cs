using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Test.Models
{
    public class MTodoSimple : IBaseData
    {
        private int _id;
        private string _header;
        private string _description;

        public int Id { get => _id; set => _id = value; }
        public string Header { get => _header; set => _header = value; }
        public string Description { get => _description; set => _description = value; }

        public string ToParamsQuery_Insert => $"(Id, Header, Description) VALUES " +
            $"(NULL, @param0, @param1)";

        public string ToParamsQuery_Update => $"Header = @param0, Description = @param1";

        public string[] ToArrayStr
        {
            get
            {
                string[] values = new string[2];

                values[0] = _header;
                values[1] = _description;

                return values;
            }
        }

        public MTodoSimple()
        {

        }

        public MTodoSimple(int id, string header, string description)
        {
            _id = id;
            _header = header;
            _description = description;
        }

        public MTodoSimple(ref MySqlDataReader mySqlDataReader)
        {
            SetData(ref mySqlDataReader);
        }

        public void SetData(ref MySqlDataReader mySqlDataReader)
        {
            _id = Convert.ToInt32(mySqlDataReader["Id"]);

            if (mySqlDataReader["Header"] != DBNull.Value)
                _header = Convert.ToString(mySqlDataReader["Header"]);
            else
                _header = "";

            if (mySqlDataReader["Description"] != DBNull.Value)
                _description = Convert.ToString(mySqlDataReader["Description"]);
            else
                _description = "";
        }
    }
}
