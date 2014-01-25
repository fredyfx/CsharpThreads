using System; //For Console
using System.Net; //For WebClient
using System.Threading; //For Threads

namespace CsharpThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Develp with Threads C#";
            DownloadAsynchronously();
            Console.WriteLine("Waiting to finish on thread {0} ... ", 
                Thread.CurrentThread.ManagedThreadId);
            
            Console.ReadLine();
        }

        private static void DownloadAsynchronously()
        {
            string[] urls =
            {
                "http://www.pluralsight.com/training",
                "http://fredyfx.com",
                "http://twitter.com/fredyfx"
            };

            foreach (var url in urls)
            {
                //Separate threads!
                var thread = new Thread(Download);
                thread.Start(url);
            }
        }

        private static void Download(object url)
        {
            var client = new WebClient();
            //Here we have to specify that url is working as string
            var html = client.DownloadString(url.ToString());
            Console.WriteLine("Download {0} chars from {1} on thread {2}",
                html.Length, url, Thread.CurrentThread.ManagedThreadId);
 
        }
    }
}
