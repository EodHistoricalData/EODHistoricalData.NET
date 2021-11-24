using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
        
        /// <summary>
        /// Returns true or false if the listing is no longer traded
        /// </summary>
        [JsonProperty("IsDelisted")]
        public bool IsDelisted { get; set; }
        
        /// <summary>
        /// The date that the listing was no longer traded
        /// </summary>
        [JsonProperty("DelistedDate")]
        public DateTimeOffset? DelistedDate { get; set; }
        
        /// <summary>
        /// The Address in a human readable form
        /// </summary>
        [JsonProperty("Address")]
        public string Address { get; set; }

        /// <summary>
        /// The Data for the Address
        /// </summary>
        [JsonProperty("AddressData")]
        public AddressData AddressData { get; set; }

        /// <summary>
        /// The different listings on different exchanges
        /// </summary>
        [JsonProperty("Listings")] 
        public Dictionary<int, Listing> Listings { get; set; }

        /// <summary>
        /// The officers for the listing if known
        /// </summary>
        [JsonProperty("Officers")] 
        public Dictionary<int, Officer> Officers { get; set; }
        
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

    public class AddressData
    {
        /// <summary>
        /// The Number and Name of the street
        /// </summary>
        [JsonProperty("Street")]
        public string Street { get; set; }
        
        /// <summary>
        /// The City of the Address
        /// </summary>
        [JsonProperty("City")]
        public string City { get; set; }
        
        /// <summary>
        /// The Country of the Address
        /// </summary>
        [JsonProperty("Country")]
        public string Country { get; set; }
        
        /// <summary>
        /// The Zip or Postcode of the Address
        /// </summary>
        [JsonProperty("ZIP")]
        public string ZIP { get; set; }
        
    }

    public class Listing
    {
        /// <summary>
        /// The Stock Code
        /// </summary>
        [JsonProperty("Code")]
        public string Code { get; set; }
        
        /// <summary>
        /// The Exchange if known
        /// Can be empty or null
        /// </summary>
        [JsonProperty("Exchange")]
        public string Exchange { get; set; }
        
        /// <summary>
        /// The Alternative Name for the Company 
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public class Officer
    {
        /// <summary>
        /// The Name of the person including their salutation
        /// example: Ms. Charlotte  Emery
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }
        
        /// <summary>
        /// The Title the person held
        /// </summary>
        [JsonProperty("Title")]
        public string Title { get; set; }
        
        /// <summary>
        /// The year that the person was born if known
        /// If Unknown returns "NA" and could be null or empty
        /// </summary>
        [JsonProperty("YearBorn")]
        public string YearBorn { get; set; }
    }
}
