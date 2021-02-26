using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksHW
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];

            Task t = Task.Run(() =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine($"{arr[i]}");
                }
            });
            t.Wait();

            Console.WriteLine(t.Status);

            if (t.IsFaulted)
            {
                t.Exception.Handle(e =>
                {
                    Console.WriteLine(e);
                    return true;
                });
            } 
        } 
    }
}
