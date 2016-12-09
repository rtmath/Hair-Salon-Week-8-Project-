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

    [Fact]
    public void Test_OverloadedEquals()
    {
      Client client1 = new Client("Jhomas Tefferson", 1);
      Client client2 = new Client("Jhomas Tefferson", 1);
      Assert.Equal(client1, client2);
    }

    [Fact]
    public void Test_SaveClientToDatabase()
    {
      Client testClient = new Client("Weorge Joshington", 2);
      testClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_FindClientInDatabase()
    {
      Client newClient = new Client("Labe Incoln", 3);
      newClient.Save();

      Client foundClient = Client.Find(newClient.Id);

      Assert.Equal(newClient, foundClient);
    }

    [Fact]
    public void Test_UpdateClientInDatabase()
    {
      string testName = "Kohn F Jennedy";
      Client testClient = new Client(testName, 4);
      testClient.Save();
      string newName = "John F Kennedy";

      testClient.Update(newName);
      string result = testClient.Name;

      Assert.Equal(newName, result);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
