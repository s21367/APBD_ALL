using System;

namespace LinqTutorials
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Collections.Generic.IEnumerable<Models.Emp> res = LinqTasks.Task12();

            foreach (Models.Emp item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
