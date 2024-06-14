using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LanguageTraining.Models
{
    public class Result : IBaseModel
    {
        private int _id;
        public int Id { get => _id; set => _id = value; }
        public int IdUser;
        public int TestScore;
        public int PracticeScore;

        public string ToParamsInsertRequest => $"(Id, IdUser, TestScore, PracticeScore) VALUES (NULL, @param0, @param1, @param2)";

        public string ToParamsUpdateRequest => $"IdUser = @param0, TestScore = @param1, PracticeScore = @param2";

        public string[] ToArrayStr => new string[] { IdUser.ToString(), TestScore.ToString(), PracticeScore.ToString() };

        public Result()
        {

        }

        public Result(int Id, int IdUser, int TestScore, int PracticeScore)
        {
            this.Id = Id;
            this.IdUser = IdUser;
            this.TestScore = TestScore;
            this.PracticeScore = PracticeScore;
        }

        public Result(ref MySqlDataReader mySqlDataReader)
        {
            SetData(ref mySqlDataReader);
        }

        public void SetData(ref MySqlDataReader mySqlDataReader)
        {
            _id = Convert.ToInt32(mySqlDataReader["Id"]);

            if (mySqlDataReader["IdUser"] != DBNull.Value)
                IdUser = Convert.ToInt32(mySqlDataReader["IdUser"]);
            else
                IdUser = -1;

            if (mySqlDataReader["TestScore"] != DBNull.Value)
                TestScore = Convert.ToInt32(mySqlDataReader["TestScore"]);
            else
                TestScore = -1;

            if (mySqlDataReader["PracticeScore"] != DBNull.Value)
                PracticeScore = Convert.ToInt32(mySqlDataReader["PracticeScore"]);
            else
                PracticeScore = -1;
        }
    }
}
