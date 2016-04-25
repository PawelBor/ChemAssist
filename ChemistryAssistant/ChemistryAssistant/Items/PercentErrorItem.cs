using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryAssistant
{
    public class PercentErrorItem
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public decimal percentRelVal { get; set; }
        
        public string percentErrorResult { get; set; }
    }
}
