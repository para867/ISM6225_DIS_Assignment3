using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Usage.Models
{
    public class Market
    {
        [Key]
        public int? MarktID { get; set; }
        public string mic { get; set; }
        public string tapeId { get; set; }
        public string venueName { get; set; }
        public Int64? volume { get; set; }
        public Int64? tapeA { get; set; }
        public Int64? tapeB { get; set; }
        public Int64? tapeC { get; set; }
        public float? marketPercent { get; set; }
        public string lastUpdated { get; set; }
    }
    public class Crypto
    {
        [Key]
        public string symbol { get; set; }
        public string companyName { get; set; }
        public string primaryExchange { get; set; }
        public string sector { get; set; }
        public float? open { get; set; }
        public float? close { get; set; }
        public float? high { get; set; }
        public float? low { get; set; }
        public float? latestPrice { get; set; }
        public string latestSource { get; set; }
        public string latestTime { get; set; }
        public string latestUpdate { get; set; }
        public Int64? latestVolume { get; set; }
        public float? change { get; set; }
        public float? changePercent { get; set; }
        public float? bidPrice{ get; set; }
        public float? askPrice{ get; set; }
    }

    public class Sector
    {
        [Key]
        public int? SectorID { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public float? performance { get; set; }
        public Int64? lastUpdated { get; set; }
    }

    public class News

    {
        [Key]
        public int? NewsID { get; set; }
        public string datetime { get; set; }
        public string headline { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string summary { get; set; }
        public string related { get; set; }
        public string image { get; set; }
    }
}