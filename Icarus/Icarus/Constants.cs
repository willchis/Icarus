﻿using Xamarin.Forms;

namespace Icarus
{
    public static class Constants
    {
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        //public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
        public static string BaseAddress = "https://api.carbonintensity.org.uk";
        public static string GenerationStats = BaseAddress + "/generation";
    }
}
