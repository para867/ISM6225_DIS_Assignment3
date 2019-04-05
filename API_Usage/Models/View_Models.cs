﻿using System.Collections.Generic;

namespace API_Usage.Models
{
  public class CompaniesEquities
  {
    public List<Company> Companies { get; set; }
    public Equity Current { get; set; }
    public string Dates { get; set; }
    public string Prices { get; set; }
    public string Volumes { get; set; }
    public float AvgPrice { get; set; }
    public double AvgVolume { get; set; }

    public CompaniesEquities(List<Company> companies, Equity current,
                                      string dates, string prices, string volumes,
                                      float avgprice, double avgvolume)
    {
      Companies = companies;
      Current = current;
      Dates = dates;
      Prices = prices;
      Volumes = volumes;
      AvgPrice = avgprice;
      AvgVolume = avgvolume;
    }
  }

  public class AzureMLModel
  {
    public string Message { get; set; }
    public string JsonObject { get; set; }
  }
}