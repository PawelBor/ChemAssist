using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistryAssistant
{
   //separate class for symbols that are not handled
   //pronounciation
   //arabic...
   //class used to hold things that will be cut out from the wikipedia string received
    public class Exceptions
    {
       
        public static string excluded = "(u03bb)|(u03af)|(u03b8)|(u03bf)|(u03c2)|(u02c8so)"+
            "|(u2014)|(u028adi)|(u0259m)|(u039d)|(u03ac)|(u03c4)|(u03c1)|(u03b9)|(u00b0C)|(u00b0F)|(u201330)|"+
            "(//string continued)|";

    };
    
}
