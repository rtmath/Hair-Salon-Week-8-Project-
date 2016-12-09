using System;
using System.Data.SqlClient;
using System.Collections.Generic;

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

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        allStylists.Add(newStylist);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allStylists;
    }
  }
}
