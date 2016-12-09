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

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool checkId = (this.Id == newClient.Id);
        bool checkName = (this.Name == newClient.Name);
        bool checkStylist = (this.StylistId == newClient.StylistId);
        return (checkId && checkName);
      }
    }

    public override int GetHashCode()
    {
      return this.Name.GetHashCode();
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int stylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientName, stylistId, clientId);
        allClients.Add(newClient);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allClients;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES(@ClientName, @StylistName)", conn);

      SqlParameter nameParam = new SqlParameter();
      nameParam.ParameterName = "@ClientName";
      nameParam.Value = this.Name;
      cmd.Parameters.Add(nameParam);

      SqlParameter stylistParam = new SqlParameter();
      stylistParam.ParameterName = "@StylistName";
      stylistParam.Value = this.StylistId;
      cmd.Parameters.Add(stylistParam);



      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        this.Id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      Console.WriteLine(this.Id + " "  + this.Name + " " + this.StylistId);
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
