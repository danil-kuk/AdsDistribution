using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AdsDistribution
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = "";
            using (StreamReader source = new StreamReader("config.json"))
            {
                config = source.ReadToEnd();
            }
            var settings = JsonConvert.DeserializeObject<ConfigSettings>(config);
            var sender = new AdsSender(settings);
            sender.SendAds(settings.GroupsIds);
        }
    }
}
