using System;
using System.Data.SqlClient;

namespace Salon.Objects
{
  public class Client
  {
    public int Id {get; set;}
    public string Name {get;set;}
    public int StylistId {get; set;}

    public Client(string cName, int sId, int cId = 0)
    {
      this.Name = cName;
      this.StylistId = sId;
      this.Id = cId;
    }
  }
}
