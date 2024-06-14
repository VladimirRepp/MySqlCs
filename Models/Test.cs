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
    public class Test : IBaseModel
    {
        private int _id;
        public int Id { get => _id; set => _id = value; }
        public string QuestionText;
        public string AnswerText_1;
        public string AnswerText_2;
        public string AnswerText_3;
        public string AnswerText_4;
        public int RightAnswerNumber;

        public string ToParamsInsertRequest => $"(Id, QuestionText, AnswerText_1, AnswerText_2, AnswerText_3, AnswerText_4, RightAnswerNumber) VALUES " +
            $"(NULL, @param0, @param1, @param2, @param3, @param4, @param5)";
        public string ToParamsUpdateRequest => $"QuestionText = @param0, AnswerText_1 = @param1, " +
            $"AnswerText_2 = @param2, AnswerText_3 = @param3, AnswerText_4 = @param4, RightAnswerNumber = @param5";

        public string[] ToArrayStr => new string[] { QuestionText, AnswerText_1, AnswerText_2, AnswerText_3, AnswerText_4, RightAnswerNumber.ToString() };

        public Test()
        {

        }

        public Test(int Id, string QuestionText,
            string AnswerText_1, string AnswerText_2, string AnswerText_3, string AnswerText_4, 
            int CurrentAnswerNumber)
        {
            this.Id = Id;
            this.QuestionText = QuestionText;
            this.AnswerText_1 = AnswerText_1;
            this.AnswerText_2 = AnswerText_2;
            this.AnswerText_3 = AnswerText_3;
            this.AnswerText_4 = AnswerText_4;
            this.RightAnswerNumber = CurrentAnswerNumber;
        }

        public Test(ref MySqlDataReader mySqlDataReader)
        {
            SetData(ref mySqlDataReader);
        }

        public void SetData(ref MySqlDataReader mySqlDataReader)
        {
            _id = Convert.ToInt32(mySqlDataReader["Id"]);

            if (mySqlDataReader["QuestionText"] != DBNull.Value)
                QuestionText = Convert.ToString(mySqlDataReader["QuestionText"]);
            else
                QuestionText = "";

            if (mySqlDataReader["AnswerText_1"] != DBNull.Value)
                AnswerText_1 = Convert.ToString(mySqlDataReader["AnswerText_1"]);
            else
                AnswerText_1 = "";

            if (mySqlDataReader["AnswerText_2"] != DBNull.Value)
                AnswerText_2 = Convert.ToString(mySqlDataReader["AnswerText_2"]);
            else
                AnswerText_2 = "";

            if (mySqlDataReader["AnswerText_3"] != DBNull.Value)
                AnswerText_3 = Convert.ToString(mySqlDataReader["AnswerText_3"]);
            else
                AnswerText_3 = "";

            if (mySqlDataReader["AnswerText_4"] != DBNull.Value)
                AnswerText_4 = Convert.ToString(mySqlDataReader["AnswerText_4"]);
            else
                AnswerText_4 = "";

            if (mySqlDataReader["RightAnswerNumber"] != DBNull.Value)
                RightAnswerNumber = Convert.ToInt32(mySqlDataReader["RightAnswerNumber"]);
            else
                RightAnswerNumber = -1;
        }
    }
}
