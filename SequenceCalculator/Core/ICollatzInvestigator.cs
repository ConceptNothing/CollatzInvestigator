using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceCalculator.Core
{
    public interface ICollatzInvestigator
    {
        public string ShowResult(string number);

        //Would be nice to have these two aswell, because algorithm of invoking calculation might have different approach in another program

        //public string MutiplyByThreeAddOne(string number);

        //public string DivideByTwo(string number);
    }
}
