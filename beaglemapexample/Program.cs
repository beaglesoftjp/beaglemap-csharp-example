using System;
using System.IO;
using System.Net;
using beaglemapexample.Model;
using Newtonsoft.Json;

namespace beaglemapexample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string url =
                "http://yahoogeo20160410094759.azurewebsites.net/api/v1/range-points-by-address/%E5%8D%83%E8%91%89%E7%9C%8C%E6%9D%BE%E6%88%B8%E5%B8%82%E6%A8%AA%E9%A0%88%E8%B3%802";

            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            Console.WriteLine(response);

            foreach (var header in response.Headers)
            {
                Console.WriteLine($"{header}:{response.Headers[header.ToString()]}");
            }

            using (var stream = response.GetResponseStream())
            {
                if (stream == null)
                {
                    Console.WriteLine("本文が取得できませんでした。");
                    return;
                }

                using (var reader = new StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();
                    Console.WriteLine("JSON ==========");
                    Console.WriteLine(jsonString);
                    Console.WriteLine("JSON ==========");
                    Console.WriteLine("");

                    var result = JsonConvert.DeserializeObject<ChomokuResultApiViewModel>(jsonString);
                    Console.WriteLine($"status:{result.Status}");
                    Console.WriteLine($"errorMessage:{result.ErrorMessage}");

                    foreach (var region in result.ChomokuRegionApiViewModels)
                    {
                        Console.WriteLine($"chomokuRegionApiViewModel.Id:{region.Id}");
                        Console.WriteLine($"chomokuRegionApiViewModel.KenCode:{region.KenCode}");
                        Console.WriteLine($"chomokuRegionApiViewModel.KenName:{region.KenName}");
                    }

                    Console.WriteLine("...");
                }
                
            }
        }
    }
}