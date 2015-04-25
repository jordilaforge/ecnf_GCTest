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
        /// Results:
        /// 
        /// settings: i5 8gb Ram rounds =10 release
        /// 
        /// GC Workstation: gcAllowVeryLargeObjects enabled="false"  gcServer enabled="false" gcConcurrent enabled="false"
        /// AverageSpaceUsed: 25.6777412414551mb AverageFreedSpace: 25.1410354614258mb AverageElaspsedTime: 12.6ms
        /// 
        /// GC Server: gcAllowVeryLargeObjects enabled="false"  gcServer enabled="true" gcConcurrent enabled="false"
        /// AverageSpaceUsed: 78.1012859344482mb AverageFreedSpace: 77.564896774292mb AverageElaspsedTime: 6.8ms
        /// 
        /// GC Concurrent Workstation: gcAllowVeryLargeObjects enabled="false"  gcServer enabled="false" gcConcurrent enabled="true"
        /// AverageSpaceUsed: 25.6858764648438mb AverageFreedSpace: 25.1496360778809mb AverageElaspsedTime: 8.3ms
        /// 
        /// GC Concurrent Server: gcAllowVeryLargeObjects enabled="false"  gcServer enabled="true" gcConcurrent enabled="true"
        /// AverageSpaceUsed: 74.3309326171875mb AverageFreedSpace: 73.7945434570313mb AverageElaspsedTime: 6.8ms
        /// 
        /// GC Concurrent Workstation VLO: gcAllowVeryLargeObjects enabled="true"  gcServer enabled="false" gcConcurrent enabled="true"
        ///AverageSpaceUsed: 25.6556671142578mb AverageFreedSpace: 25.1190185546875mb AverageElaspsedTime: 8.2ms
        /// 
        /// GC Concurrent Server VLO: gcAllowVeryLargeObjects enabled="true"  gcServer enabled="true" gcConcurrent enabled="true"
        /// AverageSpaceUsed: 101.775720214844mb AverageFreedSpace: 101.239326095581mb AverageElaspsedTime: 8.6ms
        /// 
        /// conclusion:
        /// wehnever server flag is enabled you see a win in performance but the amount of used space raises aswell.
        /// concurrent flag improves the perfomance a little bit.
        /// if you activate the VLO flag then the amount of space used raises even more if server is choicen but performance
        /// goes down. if server flag disabled and VLO enabled then there is not much of change.
        /// 
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
