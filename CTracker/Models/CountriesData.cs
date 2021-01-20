using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CTracker.Models
{
    public class CountriesData
    {

        [JsonProperty("updated")]
        public object Updated { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryInfo")]
        public CountryInfo CountryInfo { get; set; }

        [JsonProperty("cases")]
        public int Cases { get; set; }

        [JsonProperty("todayCases")]
        public int TodayCases { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("todayDeaths")]
        public int TodayDeaths { get; set; }

        [JsonProperty("recovered")]
        public int Recovered { get; set; }

        [JsonProperty("todayRecovered")]
        public int TodayRecovered { get; set; }

        [JsonProperty("active")]
        public int Active { get; set; }

        [JsonProperty("critical")]
        public int Critical { get; set; }

        [JsonProperty("casesPerOneMillion")]
        public int CasesPerOneMillion { get; set; }

        [JsonProperty("deathsPerOneMillion")]
        public double DeathsPerOneMillion { get; set; }

        [JsonProperty("tests")]
        public int Tests { get; set; }

        [JsonProperty("testsPerOneMillion")]
        public int TestsPerOneMillion { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("oneCasePerPeople")]
        public int OneCasePerPeople { get; set; }

        [JsonProperty("oneDeathPerPeople")]
        public int OneDeathPerPeople { get; set; }

        [JsonProperty("oneTestPerPeople")]
        public int OneTestPerPeople { get; set; }

        [JsonProperty("activePerOneMillion")]
        public double ActivePerOneMillion { get; set; }

        [JsonProperty("recoveredPerOneMillion")]
        public double RecoveredPerOneMillion { get; set; }

        [JsonProperty("criticalPerOneMillion")]
        public double CriticalPerOneMillion { get; set; }
    }

    public class CountryInfo
    {

        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("long")]
        public double Long { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }






    }
}
