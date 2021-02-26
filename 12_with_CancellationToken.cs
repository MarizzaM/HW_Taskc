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

            CancellationTokenSource tokenSource = new CancellationTokenSource();

            Task<int> t = new Task<int>(() =>
           {
           int sum = 1;
           int number = 1;
               Console.Write($"{number}");
               while (number < 5 && !tokenSource.IsCancellationRequested)
               {
                   Thread.Sleep(500);

                   number++;
                   sum += number;
                   
                   Console.Write($" + {number}");

               }

               return sum;

               tokenSource.Token.ThrowIfCancellationRequested();
           });

            t.Start();

            Console.ReadLine();

            tokenSource.Cancel();

            Console.WriteLine($" = {t.Result}");
        } 
    }
}
