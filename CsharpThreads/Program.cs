using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace CsharpThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Develp with Threads C#";
            DownloadSynchronously();
            Console.WriteLine("Waiting to finish on thread {0} ... ", 
                Thread.CurrentThread.ManagedThreadId);
            
            Console.ReadLine();
        }

        private static void DownloadSynchronously()
        {
            string[] urls =
            {
                "http://www.pluralsight.com/training",
                "http://fredyfx.com",
                "http://twitter.com/fredyfx"
            };

            foreach (var url in urls)
            {
                var client = new WebClient();
                var html = client.DownloadString(url);
                Console.WriteLine("Download {0} chars from {1} on thread {2}",
                    html.Length,url,Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
