using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarbageColletionTest
{
    public class Persons
    {
        /// <summary>
        /// number of threads used by the application
        /// </summary>
        private const int numebrOfThreads = 4;
        /// <summary>
        /// number of pesons wich are allocated for messurement
        /// </summary>
        private const int numberOfPersons = 100000;
        public int Count { get { return persons.Count; } }
        public List<Person> persons;
        private Object thisLock = new Object();


        public Person this[int index]
        {
            get { return persons[index]; }

            set { persons[index] = value; }
        }

        public Persons()
        {
            persons = new List<Person>();

        }
        /// <summary>
        /// creates required Persons in several Threads 
        /// because creating random PersonObject takes time
        /// </summary>
        public void CreatePersons()
        {


            Task[] tasks = new Task[numebrOfThreads];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => threadingCreatePerson(Task.CurrentId));
            }

            Task.WaitAll(tasks);
        }

        /// <summary>
        /// used for threading to create Persons
        /// </summary>
        /// <param name="number">id of the current thread</param>
        private void threadingCreatePerson(object number)
        {
            Console.WriteLine("Task: " + number + " started!");
            for (int i = 0; i < numberOfPersons / numebrOfThreads; i++)
            {
                Person p = new Person();
                lock (thisLock)
                {
                    persons.Add(p);
                }

            }
            Console.WriteLine("Task: " + number + " ended!");
        }


        /// <summary>
        /// nulls all persons to let the GarbageCollector free them
        /// </summary>
        public void NullPersons()
        {
            for (int i = 0; i < numberOfPersons; i++)
            {
                persons[i] = null;
            }
        }


    }
}
