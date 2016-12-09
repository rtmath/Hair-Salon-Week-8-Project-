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

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
