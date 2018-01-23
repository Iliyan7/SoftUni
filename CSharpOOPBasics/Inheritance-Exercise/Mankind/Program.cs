using System;

namespace Mankind
{
    class Program
    {
        public static void Main()
        {
            try
            {
                var studentInfo = Console.ReadLine()
                    .Split(' ');

                var workerInfo = Console.ReadLine()
                   .Split(' ');

                Student student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);
                Worker worker = new Worker(workerInfo[0], workerInfo[1], double.Parse(workerInfo[2]), double.Parse(workerInfo[3]));

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
