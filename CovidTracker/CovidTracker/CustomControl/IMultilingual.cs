using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CovidTracker.CustomControl
{
    public interface IMultilingual
    {
        CultureInfo CurrentCultureInfo { get; set; }
        CultureInfo DeviceCultureInfo { get; }
        CultureInfo[] CultureInfoList { get; }
        CultureInfo[] NeutralCultureInfoList { get; }
        CultureInfo GetCultureInfo(string name);
    }
}
