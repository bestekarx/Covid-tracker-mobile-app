using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CovidTracker.CustomControl;
using CovidTracker.iOS.Helpers;
using Foundation;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(IOSFontLoader))]
namespace CovidTracker.iOS.Helpers
{
    public class IOSFontLoader : IFontLoader
    {
        public void LoadFile(string bundleName)
        {
            NSError t;
            CoreGraphics.CGDataProvider provider = CoreGraphics.CGDataProvider.FromFile(bundleName);
            if (provider == null)
            {
                Debug.WriteLine("Provider " + bundleName + " is not valid.");
                return;
            }
            CoreGraphics.CGFont font = CoreGraphics.CGFont.CreateFromProvider(provider);
            if (!CoreText.CTFontManager.RegisterGraphicsFont(font, out t))
            {
                Debug.WriteLine("Unable to register font file: " + bundleName);
            }
        }
    }

}