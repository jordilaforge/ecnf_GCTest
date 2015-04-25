using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GarbageColletionTest
{
    class Program
    {
        /// <summary>
        /// Modul: ecnf
        /// Written by: Philipp Steiner
        /// Summary:
        /// This application calculates the elapsed time and the amount of space used by
        /// the specific GarbageCollector wich can by set in de App.config
        /// </summary>
        public static int rounds=10; 

        static void Main(string[] args)
        {
            if (System.Runtime.GCSettings.IsServerGC)
            {
                Console.WriteLine("Using Server GC");
            }
            else
            {
                Console.WriteLine("Using Workstation GC");
            }
            var test = new GarbageCollectionTest();
            var results = test.RunTestGC(rounds);
            Console.WriteLine("AverageSpaceUsed: " + results.Average(r => r.usedSpace) + "mb AverageFreedSpace: " + results.Average(r => r.freedSpace) + "mb AverageElaspsedTime: " + results.Average(r => r.elapsedTime) + "ms");
            Console.ReadKey();
        }


    }
}
