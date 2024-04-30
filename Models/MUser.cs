using CargoTransportation.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoTransportation.Models;

namespace CargoTransportation.Models
{
    public class MUser : IBaseData
    {
        private int _id;
        private string? _login;
        private string? _password;

        private string? _fullname;
        private string? _passport;
        private string? _position;
        private string? _email;
        private string? _phone;

        public int Id { get => _id; set => _id = value; }
        public string? Login { get => _login; set => _login = value; }
        public string? Password { get => _password; set => _password = value; }
        public string? Fullname { get => _fullname; set => _fullname = value; }
        public string? Pasport { get => _passport; set => _passport = value; }
        public string? Position { get => _position; set => _position = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Phone { get => _phone; set => _phone = value; }

        public string ToParamsQuery_Insert => $"(Id, Login, Password, Fullname, Pasport, Position, Email, Phone) VALUES " +
            $"(NULL, @param0, @param1, @param2, @param3, @param4, @param5, @param6)";

        public string ToParamsQuery_Update => $"Login = @param0, Password = @param1, " +
            $"Fullname = @param2, Pasport = @param3, Position = @param4, Email = @param5, Phone = @param6";

        public string[] ToArrayStr {
            get
            {
                string?[] values = new string[7];

                values[0] = _login;
                values[1] = _password;
                values[1] = _fullname;
                values[1] = _passport;
                values[1] = _position;
                values[1] = _email;
                values[1] = _phone;

                return values;
            }
        }

        public MUser()
        {

        }

        public MUser(int Id, string? Login, string? Password, string? Fullname, string? Pasport, string? Position, string? Email, string? Phone)
        {
            this.Id = Id;
            this.Login = Login;
            this.Password = Password;
            this.Fullname = Fullname;
            this.Pasport = Pasport;
            this.Position = Position;
            this.Email = Email;
            this.Phone = Phone;
        }

        public MUser(ref MySqlDataReader mySqlDataReader)
        {
            SetData(ref mySqlDataReader);
        }

        public void SetData(ref MySqlDataReader mySqlDataReader)
        {
            _id = Convert.ToInt32(mySqlDataReader["Id"]);

            if (mySqlDataReader["Login"] != DBNull.Value)
                Login = Convert.ToString(mySqlDataReader["Login"]);
            else
                Login = "";

            if (mySqlDataReader["Password"] != DBNull.Value)
                Password = Convert.ToString(mySqlDataReader["Password"]);
            else
                Password = "";

            if (mySqlDataReader["Fullname"] != DBNull.Value)
                Fullname = Convert.ToString(mySqlDataReader["Fullname"]);
            else
                Fullname = "";

            if (mySqlDataReader["Pasport"] != DBNull.Value)
                Pasport = Convert.ToString(mySqlDataReader["Pasport"]);
            else
                Pasport = "";

            if (mySqlDataReader["Position"] != DBNull.Value)
                Position = Convert.ToString(mySqlDataReader["Position"]);
            else
                Position = "";

            if (mySqlDataReader["Email"] != DBNull.Value)
                Email = Convert.ToString(mySqlDataReader["Email"]);
            else
                Email = "";

            if (mySqlDataReader["Phone"] != DBNull.Value)
                Phone = Convert.ToString(mySqlDataReader["Phone"]);
            else
                Phone = "";
        }
    }
}
