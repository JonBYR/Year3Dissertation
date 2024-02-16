using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Year3Project
{
    internal class ShotStatistics
    {
        int index;
        List<string> shots;
        public ShotStatistics(int i, List<string> s)
        {
            index = i;
            shots = s;
        }
        public void shotsBreakdown()
        {
            //taken from this https://stackoverflow.com/questions/1139181/a-method-to-count-occurrences-in-a-list
            var instances = shots.GroupBy(i => i);
            Console.WriteLine("For sequence {0}", index + 1);
            foreach (var grp in instances)
            {
                //int percent = (grp.Count() / shots.Count) * 100;
                Console.WriteLine("{0} appears {1} times", grp.Key, grp.Count());
            }
        }
    }
}
