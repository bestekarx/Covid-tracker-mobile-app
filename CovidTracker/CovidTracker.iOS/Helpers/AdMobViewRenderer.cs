﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CovidTracker.CustomControl;
using CovidTracker.iOS.Helpers;
using Foundation;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AdmobControl), typeof(AdMobViewRenderer))]
namespace CovidTracker.iOS.Helpers
{
    [Protocol]
    public class AdMobViewRenderer : ViewRenderer<AdmobControl, BannerView>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<AdmobControl> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(CreateBannerView());
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            Control.AdUnitID = Element.AdUnitId;
        }

        private BannerView CreateBannerView()
        {
            var bannerView = new BannerView(AdSizeCons.SmartBannerPortrait)
            {
                AdUnitID = Element.AdUnitId,
                RootViewController = GetVisibleViewController()
            };

            bannerView.LoadRequest(GetRequest());

            Request GetRequest()
            {
                var request = Request.GetDefaultRequest();
                return request;
            }

            return bannerView;
        }

        private UIViewController GetVisibleViewController()
        {
            var windows = UIApplication.SharedApplication.Windows;
            foreach (var window in windows)
            {
                if (window.RootViewController != null)
                {
                    return window.RootViewController;
                }
            }
            return null;
        }
    }
}