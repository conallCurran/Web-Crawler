using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webcrawler
{
    class Crawler
    {
        public class Crawler
        {
            public static void Main()
            {
                var crawler = new Crawler
                {
                    ExcludeFilters = new IExcludeFilter[]
                    {
                new ExcludeImagesFilter(),
                new ExcludeTrackbacks(),
                new ExcludeMailTo(),
                new ExcludeHostsExcept(new[] { "nyqui.st" }),
                new ExcludeJavaScript(),
                new ExcludeAnchors(),
                    }
                };

                crawler.OnCompleted += () =>
                {
                    Console.WriteLine("[Main] Crawl completed!");
                    Environment.Exit(0);
                };

                crawler.OnPageDownloaded += page =>
                {
                    Console.WriteLine("[Main] Downloaded page {0}", page.Url);

                    // Write external links
                    foreach (var link in page.Links)
                    {
                        if (link.TargetUrl.Host != page.Url.Host)
                        {
                            Console.WriteLine("Found outbound link from {0} to {1}", page.Url, link.TargetUrl);
                        }
                    }
                };

                crawler.Enqueue(new Uri("http://nyqui.st"));
                crawler.Start();

                Console.WriteLine("[Main] Crawler started.");
                Console.WriteLine("[Main] Press [enter] to abort.");
                Console.ReadLine();
            }
        }
    }
}
