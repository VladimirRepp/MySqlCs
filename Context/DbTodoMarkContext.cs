using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TODO_Test.Models;

namespace TODO_Test.Context
{
    public class DbTodoMarkContext : DbBaseContext<MTodoMark>
    {
        public DbTodoMarkContext()
        {
            _tableName = "todo_mark";
        }
    }
}
