using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TODO_Test.Models;

namespace TODO_Test.Context
{
    public class DbTodoSimpleContetx : DbBaseContext<MTodoSimple>
    {
        public DbTodoSimpleContetx()
        {
            _tableName = "todo_simple";
        }
    }
}
