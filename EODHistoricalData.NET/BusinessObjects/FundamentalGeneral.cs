using Newtonsoft.Json;
using System;

namespace EODHistoricalData.NET.BusinessObjects
{
    public class FundamentalGeneral
    {
        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Exchange")]
        public string Exchange { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("CurrencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty("CurrencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("CountryName")]
        public string CountryName { get; set; }

        [JsonProperty("CountryISO")]
        public string CountryIso { get; set; }

        [JsonProperty("ISIN")]
        public string Isin { get; set; }

        [JsonProperty("CUSIP")]
        public string Cusip { get; set; }

        [JsonProperty("Fund_Summary")]
        public string FundSummary { get; set; }

        [JsonProperty("Fund_Family")]
        public string FundFamily { get; set; }

        [JsonProperty("Fiscal_Year_End")]
        public string FiscalYearEnd { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("CIK")]
        public string Cik { get; set; }

        [JsonProperty("EmployerIdNumber")]
        public string EmployerIdNumber { get; set; }

        [JsonProperty("IPODate")]
        public DateTimeOffset? IpoDate { get; set; }

        [JsonProperty("InternationalDomestic")]
        public string InternationalDomestic { get; set; }

        [JsonProperty("Sector")]
        public string Sector { get; set; }

        [JsonProperty("Industry")]
        public string Industry { get; set; }

        [JsonProperty("GicSector")]
        public string GicSector { get; set; }

        [JsonProperty("GicGroup")]
        public string GicGroup { get; set; }

        [JsonProperty("GicIndustry")]
        public string GicIndustry { get; set; }

        [JsonProperty("GicSubIndustry")]
        public string GicSubIndustry { get; set; }
        
        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("WebURL")]
        public string WebUrl { get; set; }

        [JsonProperty("LogoURL")]
        public string LogoUrl { get; set; }

        [JsonProperty("FullTimeEmployees")]
        public long FullTimeEmployees { get; set; }

        [JsonProperty("UpdatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
