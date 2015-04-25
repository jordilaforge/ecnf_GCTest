using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageColletionTest
{
    public class Person
    {
        /// <summary>
        /// propertys of a Person
        /// </summary>
        public String firstname { get; set; }
        public String lastname { get; set; }
        public int age { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public String tel { get; set; }
        public String street { get; set; }
        public int houseNr { get; set; }
        public int zip { get; set; }
        public String village { get; set; }
        public String country { get; set; }



        public Person()
        {
            this.firstname = StringGenerator();
            this.lastname = StringGenerator();
            this.age = IntGenerator();
            this.weight = DoubleGenerator(0, 100);
            this.height = DoubleGenerator(1.5, 2.1);
            this.tel = StringGenerator();
            this.street = StringGenerator();
            this.houseNr = IntGenerator();
            this.zip = IntGenerator();
            this.village = StringGenerator();
            this.country = StringGenerator();
        }


        
        /// <summary>
        /// generates random strings not very inteligent but works
        /// </summary>
        /// <returns>random String</returns>
        private String StringGenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
        }

        /// <summary>
        /// generates random integer value
        /// </summary>
        /// <returns>random int</returns>
        private int IntGenerator()
        {
            Random rnd = new Random();
            return rnd.Next(100);
        }


        /// <summary>
        /// generates a random double value
        /// </summary>
        /// <param name="minimum">min value</param>
        /// <param name="maximum">max value</param>
        /// <returns>random double</returns>
        public double DoubleGenerator(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
