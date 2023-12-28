using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    public class Stopwatch
    {

        public DateTime Start()
        {
            return DateTime.Now;
        }
        public TimeSpan Stop(DateTime startTime)
        {
           return DateTime.Now - startTime;
        }

    }
}
