using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryAssistant.Model
{
    public class Reaction
    {

        //For adding new todo
        public string reactionDesc { get; set; }
        public Reaction(string what)
        {
            reactionDesc = what;
        }
    }
}
