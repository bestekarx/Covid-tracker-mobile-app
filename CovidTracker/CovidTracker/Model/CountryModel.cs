using System;
using System.Collections.Generic;
using System.Text;
using CovidTracker.Resources;

namespace CovidTracker.Model
{
    public class CountryModel
    {
        public string country { get; set; }
        public countryInfo countryInfo { get; set; }
        public double cases { get; set; }
        public double todayCases { get; set; }
        public double deaths { get; set; }
        public double todayDeaths { get; set; }
        public double recovered { get; set; }
        public double active { get; set; }
        public double critical { get; set; }
        public double casesPerOneMillion { get; set; }
        public double deathsPerOneMillion { get; set; }
        public double tests { get; set; }
        public double testsPerOneMillion { get; set; }

        public string casesString => $"{AppResources.Cases} : {cases:n0}";
        public string todayCasesString => $"{AppResources.TodayCases} : {todayCases:n0}";
        public string deathsString => $"{AppResources.Death} : {deaths:n0}";
        public string todayDeathsString => $"{AppResources.TodayDeath} : {todayDeaths:n0}";
        public string recoveredString => $"{AppResources.Recovered} : {recovered:n0}";
        public string activeString => $"{AppResources.ActiveCases} : {active:n0}";
        public string criticalString => $"{AppResources.Critical} : {critical:n0}";
        public string testsString => $"{AppResources.Test} : {tests:n0}";
        public string casesPerOneMillionString => $"{AppResources.casesPerOneMillion} : {casesPerOneMillion:n0}";
        public string deathsPerOneMillionString => $"{AppResources.deathsPerOneMillion} : {deathsPerOneMillion:n0}";
        public string testsPerOneMillionString => $"{AppResources.testsPerOneMillion} : {testsPerOneMillion:n0}";
    }
}
