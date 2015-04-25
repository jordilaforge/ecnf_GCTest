using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarbageColletionTest
{
    /// <summary>
    /// class to gather information about space and perfomance
    /// </summary>
    public class GarbageCollectionInfos
    {
        /// <summary>
        /// used GarbageCollector Space 
        /// </summary>
        public double usedSpace;
        /// <summary>
        /// space with was freed by the GarbageCollector
        /// </summary>
        public double freedSpace;
        /// <summary>
        /// elapsed time of the GarbageCollector
        /// </summary>
        public long elapsedTime;

        public GarbageCollectionInfos(double usedSpace, double freedSpace, long time)
        {
            this.usedSpace = usedSpace;
            this.freedSpace = freedSpace;
            this.elapsedTime = time;
        }

    }
}
