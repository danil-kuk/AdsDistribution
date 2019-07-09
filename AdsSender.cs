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
            Auth();
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

        public void SendAds(List<ulong> groupsIds)
        {
            var photoIds = new List<string>();
            foreach (var photoId in settings.PhotoIds)
            {
                photoIds.Add($"{vk.UserId}_{photoId}");
            }
            var photo = vk.Photo.GetById(photoIds);
            foreach (var id in groupsIds)
            {
                vk.Wall.Post(new WallPostParams
                {
                    OwnerId = -(long)id,
                    Message = settings.Message,
                    Attachments = photo
                });
            }
        }
    }
}
