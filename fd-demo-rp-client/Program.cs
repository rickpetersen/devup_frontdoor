using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace fd_demo_rp_client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var iterations = 49;
            string url = string.Empty;
            long totalMS = 0;

            if (args.Length > 0)
            {
                url = args[0];
            }
            
            if (url == string.Empty)
            {
                throw new ArgumentException("Please provide an endpoint");
            }
            var timer = new Stopwatch();
            HttpResponseMessage file;
            using (var client = new HttpClient())
            {
                //loop through n times and grab file
                for (var i = 0; i <= iterations; i++)
                {

                    timer.Start();
                    using (file = await client.GetAsync(url))
                    {
                        timer.Stop();
                        totalMS += timer.ElapsedMilliseconds;
                        Console.WriteLine($"Getting file {i + 1} : Elapsed - {timer.ElapsedMilliseconds}ms");
                        timer.Reset();
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Average transfer time: {(totalMS / iterations)}ms");

            Console.ReadLine();
        }
    }
}
