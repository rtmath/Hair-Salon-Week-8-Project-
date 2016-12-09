using System;
using System.Data.SqlClient;

namespace Salon.Objects
{
  public class Stylist
  {
    public int Id {get; set;}
    public string Name {get;set;}

    public Stylist (string sName, int sId = 0)
    {
      this.Name = sName;
      this.id = sId;
    }
  }
}
