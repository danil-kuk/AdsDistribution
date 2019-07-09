using System;
using System.Collections.Generic;
using System.Text;

namespace AdsDistribution
{
    class ConfigSettings
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public ulong AppId { get; set; }

        public List<string> GroupsIds { get; set; }

        public string Message { get; set; }

        public List<string> PhotoIds { get; set; }
    }
}
