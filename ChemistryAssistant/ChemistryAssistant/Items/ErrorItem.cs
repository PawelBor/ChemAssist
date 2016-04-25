using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryAssistant
{
    public class ErrorItem
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public decimal experimentalValue { get; set; }
        public decimal knownValue { get; set; }
        public string errorValueResult { get; set; }
    }

   
}
