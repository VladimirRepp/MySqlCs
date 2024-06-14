using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTraining.Models
{
    public interface IBaseModel
    {
        int Id { get; set; }

        string ToParamsInsertRequest { get; } 
        string ToParamsUpdateRequest { get; }

        string[] ToArrayStr { get; }

        void SetData(ref MySqlDataReader mySqlDataReader);
    }
}
