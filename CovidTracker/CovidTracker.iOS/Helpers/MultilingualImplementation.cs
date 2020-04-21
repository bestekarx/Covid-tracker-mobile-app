using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using CovidTracker.CustomControl;
using CovidTracker.iOS.Helpers;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(MultilingualImplementation))]
namespace CovidTracker.iOS.Helpers
{
    /// <summary>
    /// Implementation for Multilingual
    public class MultilingualImplementation : IMultilingual
    {
        CultureInfo _currentCultureInfo = CultureInfo.InstalledUICulture;
        public CultureInfo CurrentCultureInfo
        {
            get
            {
                return _currentCultureInfo;
            }
            set
            {
                _currentCultureInfo = value;
                Thread.CurrentThread.CurrentCulture = value;
                Thread.CurrentThread.CurrentUICulture = value;
            }
        }

        public CultureInfo DeviceCultureInfo
        {
            get
            {
                try
                {
                    if (NSLocale.PreferredLanguages.Length > 1)
                    {
                        string cn = NSLocale.PreferredLanguages[0].ToString().Split('-')[0];
                        return new System.Globalization.CultureInfo(cn);
                    }
                }
                catch (Exception ex)
                {
                }
                return CultureInfo.InstalledUICulture;
            }
        }

        public CultureInfo[] CultureInfoList { get { return CultureInfo.GetCultures(CultureTypes.AllCultures); } }

        public CultureInfo[] NeutralCultureInfoList { get { return CultureInfo.GetCultures(CultureTypes.NeutralCultures); } }

        public CultureInfo GetCultureInfo(string name) { return CultureInfo.GetCultureInfo(name); }
    }
}