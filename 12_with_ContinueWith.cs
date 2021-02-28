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

            int number = 1;
            int sum = 0;

            Task<int> t = Task<int>.Run(() =>
            {
                tokenSource.Token.ThrowIfCancellationRequested();
                Console.Write($"{number} + ");
                sum = number;
                return sum;

            }, tokenSource.Token).ContinueWith((Task<int> result) =>
            {
                tokenSource.Token.ThrowIfCancellationRequested();
                Thread.Sleep(500);
                number++;
                Console.Write($"{number} + ");
                return result.Result + number;

            }, tokenSource.Token).ContinueWith((Task<int> result) =>
            {
                tokenSource.Token.ThrowIfCancellationRequested();
                Thread.Sleep(500);
                number++;
                Console.Write($"{number} + ");
                return result.Result + number;

            }, tokenSource.Token).ContinueWith((Task<int> result) =>
            {
                tokenSource.Token.ThrowIfCancellationRequested();
                Thread.Sleep(500);
                number++;
                Console.Write($"{number} + ");
                return result.Result + number;

            }, tokenSource.Token).ContinueWith((Task<int> result) =>
            {
                tokenSource.Token.ThrowIfCancellationRequested();
                Thread.Sleep(500);
                number++;
                Console.Write($"{number}");
                return result.Result + number;

            }, tokenSource.Token);

            Console.ReadLine();

            tokenSource.Cancel();


            try
            {
                Console.WriteLine($" = {t.Result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine(t.IsCanceled);
            Console.WriteLine(t.IsFaulted);

        }
    }
}
