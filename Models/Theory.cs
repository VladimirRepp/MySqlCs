using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LanguageTraining.Models
{
    public class Theory : IBaseModel
    {
        private int _id;
        public int Id { get => _id; set => _id = value; }
        public string Title;
        public string Text;

        public string ToParamsInsertRequest => $"(Id, Title, Text) VALUES (NULL, @param0, @param1)";
        public string ToParamsUpdateRequest => $"Title = @param0, Text = @param1";

        public string[] ToArrayStr => new string[] { Title, Text};

        public Theory()
        {

        }

        public Theory(int Id, string Title, string Text)
        {
            this.Id = Id;
            this.Title = Title;
            this.Text = Text;
        }

        public Theory(ref MySqlDataReader mySqlDataReader)
        {
            SetData(ref mySqlDataReader);
        }

        public void SetData(ref MySqlDataReader mySqlDataReader)
        {
            _id = Convert.ToInt32(mySqlDataReader["Id"]);

            if (mySqlDataReader["Title"] != DBNull.Value)
                Title = Convert.ToString(mySqlDataReader["Title"]);
            else
                Title = "";

            if (mySqlDataReader["Text"] != DBNull.Value)
                Text = Convert.ToString(mySqlDataReader["Text"]);
            else
                Text = "";
        }
    }
}
