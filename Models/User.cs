using MySql.Data.MySqlClient;
using System;

namespace LanguageTraining.Models
{
    public class User : IBaseModel
    {
        private int _id;
        public int Id { get => _id; set => _id = value; }
        public string Login;
        public string Password;
        public string Role;
        public string Fullname;
        public string Email;
        public string Phone;
        public string DateOfBirth;

        public string ToParamsInsertRequest => $"(Id, Login, Password, Role, Fullname, Email, Phone, DateOfBirth) VALUES " +
            $"(NULL, @param0, @param1, @param2, @param3, @param4, @param5, @param6)";

        public string ToParamsUpdateRequest => $"Login = @param0, Password = @param1, " +
            $"Role = @param2, Fullname = @param3, Email = @param4, Phone = @param5, DateOfBirth = @param6";

        public string[] ToArrayStr => new string[] { Login, Password, Role, Fullname, Email, Phone, DateOfBirth };

        public User()
        {

        }

        public User(int Id, string Login, string Password, string Role, string Fullname, string Email, string Phone, string DateOfBirth)
        {
            this.Id = Id;
            this.Login = Login;
            this.Password = Password;
            this.Role = Role;
            this.Fullname = Fullname;
            this.Email = Email;
            this.Phone = Phone;
            this.DateOfBirth = DateOfBirth;
        }

        public User(ref MySqlDataReader mySqlDataReader)
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

            if (mySqlDataReader["Role"] != DBNull.Value)
                Role = Convert.ToString(mySqlDataReader["Role"]);
            else
                Role = "";

            if (mySqlDataReader["Fullname"] != DBNull.Value)
                Fullname = Convert.ToString(mySqlDataReader["Fullname"]);
            else
                Fullname = "";

            if (mySqlDataReader["Email"] != DBNull.Value)
                Email = Convert.ToString(mySqlDataReader["Email"]);
            else
                Email = "";

            if (mySqlDataReader["Phone"] != DBNull.Value)
                Phone = Convert.ToString(mySqlDataReader["Phone"]);
            else
                Phone = "";

            if (mySqlDataReader["DateOfBirth"] != DBNull.Value)
                DateOfBirth = Convert.ToString(mySqlDataReader["DateOfBirth"]);
            else
                DateOfBirth = "";
        }
    }
}
