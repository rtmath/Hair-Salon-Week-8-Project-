using Xunit;
using System;
using System.Data;
using System.Collections.Generic;
using Salon.Startup;
using Salon.Objects;

namespace Salon.Tests
{
  public class ClientTests : IDisposable
  {
    public void ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DBReturnsEmptyAtFirst()
    {
      Assert.Equal(0, Client.GetAll().Count);
    }

    public void Dispose()
    {
      //DeleteAll() here
    }
  }
}
