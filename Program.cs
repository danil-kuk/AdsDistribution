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
            var config = "";
            try
            {
                config = File.ReadAllText("config.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка! Не найден файл config.txt");
            }
            var settings = JsonConvert.DeserializeObject<ConfigSettings>(config);
            var sender = new AdsSender(settings);
            try
            {
                sender.SendAds(settings.GroupsIds);
            }
            catch (Exception)
            {
                Console.WriteLine("Возникла ошибка! Ну удалось сделать рассылку");
            }
            Console.WriteLine("Работа завершена, нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}
