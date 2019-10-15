using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class ParallelAsync
    {
        public async Task IntialCall_ParallelAsync()
        {
            Console.WriteLine($"Async Parallel Operation:");
            var watcher = System.Diagnostics.Stopwatch.StartNew();

            await RunDownload_ParallelAsync();

            watcher.Stop();
            var millisecond = watcher.ElapsedMilliseconds;
            Console.WriteLine($"Total Time Taken: {millisecond}");

        }

       

        async Task RunDownload_ParallelAsync()
        {
            List<string> Websites = PreData();
            List<Task<Website_VM>> tasks = new List<Task<Website_VM>>(); 

            foreach (var item in Websites)
            {
                //Website_VM result = await Task.Run(() => downloadwebsite(item));

                tasks.Add(Task.Run(() => downloadwebsite(item))); 
                // I got list i want you to download it , next one download it and next one download it , Now all these are doing is 
                //Grabbing that Task back here's the bubble of work and kind of holding on to it.
                // and we are putting those bobble of work in this tasks list then when all of them are done grab result of all them 
                //loop through them and report , show us until they're done  
            }

            var results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                ReportWebsiteInfo(item); 
            }

            
        }

        List<string> PreData()
        {
            List<string> output = new List<string>();


            output.Add("https://www.yahoo.com");
            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.facebook.com");
            output.Add("https://www.sqlservercentral.com");

            return output;
        }
        void ReportWebsiteInfo(Website_VM data)
        {
            Console.WriteLine($"{data.WebSiteUrl} , Downloaded: {data.WebSiteData.Length} , Characters Long. {Environment.NewLine}");
        }

        Website_VM downloadwebsite(string url)
        {
            WebClient webClient = new WebClient();
            var obj = new Website_VM { WebSiteUrl = url, WebSiteData = webClient.DownloadString(url) };
            return obj;
        }
    }
}
