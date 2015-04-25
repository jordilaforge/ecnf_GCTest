using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GarbageColletionTest
{
    public class GarbageCollectionTest
    {
        /// <summary>
        /// List of GarbageCollectorInfos
        /// </summary>
        public List<GarbageCollectionInfos> gbcInfos { get; set; }

        public GarbageCollectionTest()
        {
            gbcInfos = new List<GarbageCollectionInfos>();
        }

        /// <summary>
        /// This Method is used to run a test several times to determin the performance of
        /// a specific Garbage Collector configured in the App config
        /// </summary>
        /// <param name="rounds">the amound of round the test takes</param>
        /// <returns>returns a list of GarbageColletionsInfos</returns>
        public List<GarbageCollectionInfos> RunTestGC(int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                Console.WriteLine("----------------Round"+i+"--------------------------");
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;
                Persons persons = new Persons();
                Console.WriteLine("Creating Persons....");
                persons.CreatePersons();
                Console.WriteLine(persons.Count + " Persons created....");
                double usedSpace = ConvertBytesToMegabytes(GC.GetTotalMemory(false));
                Console.WriteLine(usedSpace + "mb used by GC");
                Console.WriteLine("Nulling Persons...");
                persons.NullPersons();
                Console.WriteLine(persons.Count + " Nulled Persons");
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Console.WriteLine("starting GC....");
                GC.Collect();
                double freedSpace = usedSpace - ConvertBytesToMegabytes(GC.GetTotalMemory(false));
                Console.WriteLine(freedSpace + "mb freed by GC");
                Console.WriteLine("GC ended.....");
                sw.Stop();
                gbcInfos.Add(new GarbageCollectionInfos(usedSpace, freedSpace, sw.ElapsedMilliseconds));
                Console.WriteLine("GC Time: Elapsed={0}", sw.Elapsed);
            }
            return gbcInfos;
        }


        /// <summary>
        /// Converst Bytes to Megabytes
        /// </summary>
        /// <param name="bytes">number of bytes</param>
        /// <returns>nukber of megabytes</returns>
        private double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}
