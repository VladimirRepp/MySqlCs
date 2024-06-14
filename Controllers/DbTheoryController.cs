using LanguageTraining.Context;
using LanguageTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTraining.Controllers
{
    public class DbTheoryController : DbBaseController<Theory>
    {
        public DbTheoryController() {
            _tableName = "Theory";
        }
    }
}
