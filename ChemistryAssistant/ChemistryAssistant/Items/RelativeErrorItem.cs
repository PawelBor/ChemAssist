using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryAssistant
{
    public class RelativeErrorItem
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public decimal errorValue { get; set; }
        public decimal relativeKnownValue { get; set; }
        public string relativeErrorValue { get; set; }
    }
}
