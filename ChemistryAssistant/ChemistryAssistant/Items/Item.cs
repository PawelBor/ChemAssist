using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryAssistant
{
    //item class
    //holds all getters & setters functions
    //PK & AI used in conjunction with SQLiteDB
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public decimal m1 { get; set; }
        public decimal v1 { get; set; }
        public decimal m2 { get; set; }
        public decimal v2 { get; set; }
        public string resultCalc { get; set; }
    }

}
