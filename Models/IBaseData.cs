using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_Test.Models
{
    public interface IBaseData
    {
        int Id { get; set; }

        string ToParamsQuery_Insert { get; } 
        string ToParamsQuery_Update { get; }

        string[] ToArrayStr { get; }

        void SetData(ref MySqlDataReader mySqlDataReader);
    }
}
