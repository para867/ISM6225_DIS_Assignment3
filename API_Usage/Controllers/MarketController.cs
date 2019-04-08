using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_Usage.Models;
using System.Net.Http;
using Newtonsoft.Json;
using API_Usage.DataAccess;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Usage.Controllers
{
    public class MarketController : Controller
    {

        public ApplicationDbContext dbContext;

        internal static List<Market> Mrkt = new List<Market>();

        string BASE_URL = "https://api.iextrading.com/1.0/";
        HttpClient httpClient;

        public MarketController(ApplicationDbContext context)
        {
            dbContext = context;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public IActionResult Market()
        {
            //Set ViewBag variable first
            ViewBag.dbSucessComp = 0;
            List<Market> Market = GetMarket();

            //Save Market in TempData, so they do not have to be retrieved again
            TempData["market"] = JsonConvert.SerializeObject(Market);

            return View(Market);
        }

        public List<Market> GetMarket()
        {
            // string to specify information to be retrieved from the API
            string IEXTrading_API_PATH = BASE_URL + "/market";

            // initialize objects needed to gather data
            string market = "";
            List<Market> Market = null;
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);

            // connect to the API and obtain the response
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // now, obtain the Json objects in the response as a string
            if (response.IsSuccessStatusCode)
            {
                market = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // parse the string into appropriate objects
            if (!market.Equals(""))
            {
                Market = JsonConvert.DeserializeObject<List<Market>>(market);
            }

            return Market;
        }

        public IActionResult PopulateMarket()
        {
            // retrieve the companies that were saved in the symbols method
            // saving in TempData is extremely inefficient - the data circles back from the browser
            // better methods would be to serialize to the hard disk, or save directly into the database
            //  in the symbols method. This example has been structured to demonstrate one way to save object data
            //  and retrieve it later
            List<Market> Mrkt = JsonConvert.DeserializeObject<List<Market>>(TempData["market"].ToString());

            foreach (Market market in Mrkt)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Markets.Where(c => c.mic.Equals(market.mic)).Count() == 0)
                {
                    dbContext.Markets.Add(market);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Market", Mrkt);
        }
        // fix the relations. By default the quotes do not have the company symbol
        //  this symbol serves as the foreign key in the database and connects the quote to the company


        public IActionResult Crypto()
        {
            //Set ViewBag variable first
            ViewBag.dbSucessComp = 0;
            List<Crypto> Crypto = GetCrypto();

            //Save Market in TempData, so they do not have to be retrieved again
            TempData["crypto"] = JsonConvert.SerializeObject(Crypto);

            return View(Crypto);
        }

        public List<Crypto> GetCrypto()
        {
            // string to specify information to be retrieved from the API
            string IEXTrading_API_PATH = BASE_URL + "/stock/market/crypto";

            // initialize objects needed to gather data
            string crypto = "";
            List<Crypto> Crypto = null;
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);

            // connect to the API and obtain the response
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // now, obtain the Json objects in the response as a string
            if (response.IsSuccessStatusCode)
            {
                crypto = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // parse the string into appropriate objects
            if (!crypto.Equals(""))
            {
                Crypto = JsonConvert.DeserializeObject<List<Crypto>>(crypto);
            }

            return Crypto;
        }

        public IActionResult PopulateCryto()
        {
            // retrieve the companies that were saved in the symbols method
            // saving in TempData is extremely inefficient - the data circles back from the browser
            // better methods would be to serialize to the hard disk, or save directly into the database
            //  in the symbols method. This example has been structured to demonstrate one way to save object data
            //  and retrieve it later
            List<Crypto> crypt = JsonConvert.DeserializeObject<List<Crypto>>(TempData["crypto"].ToString());

            foreach (Crypto crypto in crypt)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Cryptos.Where(c => c.symbol.Equals(crypto.symbol)).Count() == 0)
                {
                    dbContext.Cryptos.Add(crypto);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Crypto", crypt);
        }
        // fix the relations. By default the quotes do not have the company symbol
        //  this symbol serves as the foreign key in the database and connects the quote to the company

        public IActionResult Sector()
        {
            //Set ViewBag variable first
            ViewBag.dbSucessComp = 0;
            List<Sector> Sector = GetSector();

            //Save Market in TempData, so they do not have to be retrieved again
            TempData["sector"] = JsonConvert.SerializeObject(Sector);

            return View(Sector);
        }

        public List<Sector> GetSector()
        {
            // string to specify information to be retrieved from the API
            string IEXTrading_API_PATH = BASE_URL + "/stock/market/sector-performance";

            // initialize objects needed to gather data
            string sector = "";
            List<Sector> Sector = null;
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);

            // connect to the API and obtain the response
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // now, obtain the Json objects in the response as a string
            if (response.IsSuccessStatusCode)
            {
                sector = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // parse the string into appropriate objects
            if (!sector.Equals(""))
            {
                Sector = JsonConvert.DeserializeObject<List<Sector>>(sector);
            }

            return Sector;
        }

        public IActionResult PopulateSector()
        {
            // retrieve the companies that were saved in the symbols method
            // saving in TempData is extremely inefficient - the data circles back from the browser
            // better methods would be to serialize to the hard disk, or save directly into the database
            //  in the symbols method. This example has been structured to demonstrate one way to save object data
            //  and retrieve it later
            List<Sector> sect = JsonConvert.DeserializeObject<List<Sector>>(TempData["sector"].ToString());

            foreach (Sector sector in sect)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Sectors.Where(c => c.name.Equals(sector.name)).Count() == 0)
                {
                    dbContext.Sectors.Add(sector);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Sector", sect);
        }
        // fix the relations. By default the quotes do not have the company symbol
        //  this symbol serves as the foreign key in the database and connects the quote to the company

        public IActionResult News()
        {
            //Set ViewBag variable first
            ViewBag.dbSucessComp = 0;
            List<News> News = GetNews();

            //Save Market in TempData, so they do not have to be retrieved again
            TempData["news"] = JsonConvert.SerializeObject(News);

            return View(News);
        }

        public List<News> GetNews()
        {
            // string to specify information to be retrieved from the API
            string IEXTrading_API_PATH = BASE_URL + "/stock/aapl/news";

            // initialize objects needed to gather data
            string news = "";
            List<News> News = null;
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);

            // connect to the API and obtain the response
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // now, obtain the Json objects in the response as a string
            if (response.IsSuccessStatusCode)
            {
                news = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // parse the string into appropriate objects
            if (!news.Equals(""))
            {
                News = JsonConvert.DeserializeObject<List<News>>(news);
            }

            return News;
        }

        public IActionResult PopulateNews()
        {
            // retrieve the companies that were saved in the symbols method
            // saving in TempData is extremely inefficient - the data circles back from the browser
            // better methods would be to serialize to the hard disk, or save directly into the database
            //  in the symbols method. This example has been structured to demonstrate one way to save object data
            //  and retrieve it later
            List<News> nws = JsonConvert.DeserializeObject<List<News>>(TempData["news"].ToString());

            foreach (News news in nws)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.TNews.Where(c => c.headline.Equals(news.headline)).Count() == 0)
                {
                    dbContext.TNews.Add(news);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("News", nws);
        }
        // fix the relations. By default the quotes do not have the company symbol
        //  this symbol serves as the foreign key in the database and connects the quote to the company

    }
}