using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Async
    {
        public async Task IntialCallAsync()
        {
            Console.WriteLine($"Async Operation:");
            var watcher = System.Diagnostics.Stopwatch.StartNew();

            await RunDownload_Async();

            watcher.Stop();
            var millisecond = watcher.ElapsedMilliseconds;
            Console.WriteLine($"Total Time Taken: {millisecond}");

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

        async Task RunDownload_Async()
        {
            List<string> Websites = PreData();
            foreach (var item in Websites)
            {
                Website_VM result = await Task.Run(() => downloadwebsite(item));
                ReportWebsiteInfo(result);
            }
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
