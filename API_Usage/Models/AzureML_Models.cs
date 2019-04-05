using System.Collections.Generic;

namespace API_Usage.Models
{
  public class StringTable
  {
    public string[] ColumnNames { get; set; }
    public string[,] Values { get; set; }
  }

  public class Value
  {
    public List<string> ColumnNames { get; set; }
    public List<string> ColumnTypes { get; set; }
    public List<List<string>> Values { get; set; }
  }

  public class Output1
  {
    public string type { get; set; }
    public Value value { get; set; }
  }

  public class Results
  {
    public Output1 output1 { get; set; }
  }

  public class RootObject
  {
    public Results Results { get; set; }
  }
}