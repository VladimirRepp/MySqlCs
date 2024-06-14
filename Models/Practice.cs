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
    public class Practice : IBaseModel
    {
        private int _id;
        public int Id { get => _id; set => _id = value; }
        public string Text;
        public string RightWord;

        public string ToParamsInsertRequest => $"(Id, Text, RightWord) VALUES (NULL, @param0, @param1)";

        public string ToParamsUpdateRequest => $"Text = @param0, RightWord = @param1";

        public string[] ToArrayStr => new string[]{ Text, RightWord};

        public Practice()
        {

        }

        public Practice(int Id, string Text, string RightWord)
        {
            this.Id = Id;
            this.Text = Text;;
            this.RightWord = RightWord;
        }

        public Practice(ref MySqlDataReader mySqlDataReader)
        {
            SetData(ref mySqlDataReader);
        }

        public void SetData(ref MySqlDataReader mySqlDataReader)
        {
            _id = Convert.ToInt32(mySqlDataReader["Id"]);

            if (mySqlDataReader["Text"] != DBNull.Value)
                Text = Convert.ToString(mySqlDataReader["Text"]);
            else
                Text = "";

            if (mySqlDataReader["RightWord"] != DBNull.Value)
                RightWord = Convert.ToString(mySqlDataReader["RightWord"]);
            else
                RightWord = "";
        }
    }
}
