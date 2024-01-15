using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

namespace Marbels
{
    public class MarbelsSolution
    {
        public static long MaxMinScoreDifference(int[] weights, int k)
        {
            var sums = new int[weights.Length - 1];

            for (int i = 0; i < weights.Length - 1; i++)
                sums[i] = weights[i] + weights[i + 1];

            Array.Sort(sums);

            //use long because overflow can happened for int
            //the same reason to do not ue linq Sum operation
            long minimum = 0;
            sums.Take(k - 1).ToList()
                .ForEach(x => minimum += x);

            long maximum = 0;
            sums.TakeLast(k - 1).ToList()
                .ForEach(x => maximum += x);

            return maximum - minimum;

        }
    }
    
}
