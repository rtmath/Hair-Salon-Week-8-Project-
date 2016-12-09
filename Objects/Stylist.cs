using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Salon.Objects
{
  public class Stylist
  {
    public int Id {get; set;}
    public string Name {get;set;}

    public Stylist (string sName, int sId = 0)
    {
      this.Name = sName;
      this.Id = sId;
    }


    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool checkId = (this.Id == newStylist.Id);
        bool checkName = (this.Name == newStylist.Name);
        return (checkId && checkName);
      }
    }

    public override int GetHashCode()
    {
      return this.Name.GetHashCode();
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

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name) OUTPUT INSERTED.id VALUES(@StylistName)", conn);

      SqlParameter nameParam = new SqlParameter();
      nameParam.ParameterName = "@StylistName";
      nameParam.Value = this.Name;
      cmd.Parameters.Add(nameParam);
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
    }

    public static Stylist Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = (@StylistId)", conn);

      SqlParameter idParam = new SqlParameter();
      idParam.ParameterName   = "@StylistId";
      idParam.Value = id.ToString();
      cmd.Parameters.Add(idParam);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundStylistId = 0;
      string foundStylistName = null;

      while (rdr.Read())
      {
        foundStylistId = rdr.GetInt32(0);
        foundStylistName = rdr.GetString(1);
      }
      Stylist newStylist = new Stylist(foundStylistName, foundStylistId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return newStylist;
    }

    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE stylists SET name = @newName OUTPUT INSERTED.name WHERE id = @StylistId;", conn);

      SqlParameter newNameParam = new SqlParameter();
      newNameParam.ParameterName = "@newName";
      newNameParam.Value = newName;
      cmd.Parameters.Add(newNameParam);

      SqlParameter idParam = new SqlParameter();
      idParam.ParameterName = "@StylistId";
      idParam.Value = this.Id;
      cmd.Parameters.Add(idParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Name = rdr.GetString(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM stylists WHERE id = @StylistId; DELETE FROM clients WHERE stylist_id = @StylistId;", conn);

      SqlParameter idParam = new SqlParameter();
      idParam.ParameterName = "@StylistId";
      idParam.Value = this.Id;
      cmd.Parameters.Add(idParam);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists; DELETE FROM clients", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
