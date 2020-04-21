using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovidTracker.CustomControl;
using CovidTracker.Model;
using Xamarin.Forms;
using ItemTappedEventArgs = Syncfusion.ListView.XForms.ItemTappedEventArgs;

namespace CovidTracker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : BaseContentPage
    {
        private GetAllData data;
        private List<CountryModel> countryList = new List<CountryModel>();
        public MainPage()
        {
            InitializeComponent();

            Init();
        }

        async void Init()
        {
            data = await Api.AllData();
            if (data != null)
            {
                lblCases.Text = data.cases.ToString("n0");
                lblDeath.Text = data.deaths.ToString("n0");
                lblRecovered.Text = data.recovered.ToString("n0");
                lblTodayCases.Text = data.todayCases.ToString("n0");
                lblTodayDeath.Text = data.todayDeaths.ToString("n0");
                lblActiveCases.Text = data.active.ToString("n0");
            }

            countryList = await Api.GetCountryData();
            if(countryList != null)
                listView.ItemsSource = countryList.OrderByDescending(q=>q.cases).Take(100);

            AdmobControl admobControl = new AdmobControl()
            {
                AdUnitId = AppConstants.BannerId
            };
            st_admob.Children.Add(admobControl);
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = entr_search.Text;
            if (countryList != null && countryList.Count > 0)
            {
                var lw = countryList.Where(w => w.country.ToLower().Contains(keyword.ToLower())).ToList();
                listView.ItemsSource = lw;

                if (String.IsNullOrEmpty(keyword))
                {
                    listView.ItemsSource = countryList.OrderByDescending(q => q.cases).Take(100);
                }
            }
         
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Mdl = (CountryModel)e.ItemData;
            App.Instance.ShowPopup(new Detail(Mdl));
        }
    }
}
