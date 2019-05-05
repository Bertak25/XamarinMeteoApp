using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.FirebasePushNotification;

namespace MeteoApp.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }
        public override void OnCreate()
        {
            base.OnCreate();
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";
            }
            FirebasePushNotificationManager.Initialize(this, true);
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
            };
        }
    }
}