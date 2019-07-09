using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AdsDistribution
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = File.ReadAllText("config.txt");
            var settings = JsonConvert.DeserializeObject<ConfigSettings>(config);
            var sender = new AdsSender(settings);
            sender.SendAds(settings.GroupsIds);
        }
    }
}
