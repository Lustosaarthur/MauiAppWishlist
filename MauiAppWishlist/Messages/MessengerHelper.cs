using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppWishlist.Messages
{
    public static class MessengerHelper
    {
        public static event Action<ReloadDataMessage> ReloadDataRequested;

        public static void SendReloadDataMessage()
        {
            ReloadDataRequested?.Invoke(new ReloadDataMessage());
        }
    }
}
