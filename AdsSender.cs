using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace AdsDistribution
{
    class AdsSender
    {
        private static readonly VkApi vk = new VkApi();
        private readonly ConfigSettings settings;

        public AdsSender(ConfigSettings settings)
        {
            this.settings = settings;
            try
            {
                Auth();
                Console.WriteLine("Вход выполнен");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка авторизации! Проверьте данные в файле config.txt");
            }
        }

        private void Auth()
        {
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = settings.AppId,
                Login = settings.Login,
                Password = settings.Password,
                Settings = Settings.All
            });
        }

        public void SendAds(List<string> groupsIds)
        {
            var photoIds = new List<string>();
            foreach (var photoId in settings.PhotoIds)
            {
                photoIds.Add($"{vk.UserId}_{photoId}");
            }
            var photo = vk.Photo.GetById(photoIds);
            foreach (var id in groupsIds)
            {
                try
                {
                    vk.Wall.Post(new WallPostParams
                    {
                        OwnerId = long.Parse("-" + id),
                        Message = settings.Message,
                        Attachments = photo
                    });
                    Console.WriteLine("Сделан пост в " + TryGetGroupName(id));
                }
                catch (Exception)
                {
                    Console.WriteLine("Не удалось сделать пост в " + TryGetGroupName(id));
                }
            }
        }

        private string TryGetGroupName(string groupId)
        {
            try
            {
                var group = vk.Groups.GetById(null, groupId, null);
                return group[0].Name;
            }
            catch (Exception)
            {
                return "id" + groupId;
            }
        }
    }
}
