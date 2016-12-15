using Xunit;
using System;
using System.Data;
using System.Collections.Generic;
using Salon.Startup;
using Salon.Objects;

namespace Salon.Tests
{
  public class StylistTests : IDisposable
  {
    public void StylistTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DBReturnsEmptyAtFirst()
    {
      Assert.Equal(0, Stylist.GetAll().Count);
    }

    [Fact]
    public void Test_OverloadedEquals()
    {
      Stylist stylist1 = new Stylist("Timmy Jenkins");
      Stylist stylist2 = new Stylist("Timmy Jenkins");
      Assert.Equal(stylist1, stylist2);
    }

    [Fact]
    public void Test_SaveStylistToDatabase()
    {
      Stylist testStylist = new Stylist("Mannah Hontana");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_FindStylistInDatabase()
    {
      Stylist newStylist = new Stylist("Mony Tontana");
      newStylist.Save();

      Stylist foundStylist = Stylist.Find(newStylist.Id);

      Assert.Equal(newStylist, foundStylist);
    }

    [Fact]
    public void Test_UpdateStylistInDatabase()
    {
      string testName = "Mill Burray";
      Stylist testStylist = new Stylist(testName);
      testStylist.Save();
      string newName = "Bill Murray";

      testStylist.Update(newName);
      string result = testStylist.Name;

      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_DeleteStylistFromDatabase()
    {
      string stylistName1 = "Bobby Jo";
      Stylist stylist1 = new Stylist(stylistName1);
      stylist1.Save();

      string stylistName2 = "Johnathan Pib";
      Stylist stylist2 = new Stylist(stylistName2);
      stylist2.Save();

      Client regularClient = new Client("Cousin Itt", stylist1.Id);
      regularClient.Save();
      Client newClient = new Client("Uncle Fester", stylist2.Id);
      newClient.Save();

      stylist2.Delete();
      List<Stylist> resultStylists = Stylist.GetAll();
      List <Stylist> testStylistList = new List<Stylist> {stylist1};

      Assert.Equal(resultStylists, testStylistList);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
