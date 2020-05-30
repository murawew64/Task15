using System;

namespace Task15
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var hospital = new Hospital(5, 10, 1,
                @"D:\program1\C#\Programs\Task15\log.log"))
            {
                try
                {
                     //var hospital = new Hospital(5, 5, 5);
                    hospital.StartSimulation();
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

        }
    }
}
