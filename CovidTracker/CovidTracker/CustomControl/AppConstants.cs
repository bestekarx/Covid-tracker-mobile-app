using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CovidTracker.CustomControl
{
    public static class AppConstants
    {
        public static string AppId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-5910907483154589~3395254993";
                    default:
                        return "ca-app-pub-5910907483154589~3395254993";
                }
            }
        }

        /// <summary>
        /// These Ids are test Ids from https://developers.google.com/admob/android/test-ads
        /// </summary>
        /// <value>The banner identifier.</value>
        public static string BannerId
        {

            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-5910907483154589/9984714070";
                    default:
                        return "ca-app-pub-5910907483154589/9984714070";
                }
            }
        }
    }
}
