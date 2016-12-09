using Nancy;
using System.Collections.Generic;
using Salon.Objects;

namespace Salon.Modules
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/new_stylist"] = _ => View["new_sform.cshtml"];
      Get["/new_client"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["new_cform.cshtml", allStylists];
      };
      Post["/add_stylist"] = _ =>
      {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["index.cshtml"];
      };
      Post["/add_client"] = _ =>
      {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["index.cshtml"];
      };
      Get["/list_stylists"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/list_clients"] = _ =>
      {
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };
    }
  }
}
