using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryAssistant.Model
{
    public class Note
    {
        public string quickNote { get; set; }
        public Note(string notewht)
        {
            quickNote = notewht;
        }
    }
}
