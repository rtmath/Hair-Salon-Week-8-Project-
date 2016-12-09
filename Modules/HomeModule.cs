using Nancy;
using System.Linq;
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
        return View["new_sform.cshtml"];
      };
      Post["/add_client"] = _ =>
      {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
        newClient.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["new_cform.cshtml", allStylists];
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
      Get["/remove_stylist"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["remove_stylist.cshtml", allStylists];
      };
      Get["/remove_client"] = _ =>
      {
        List<Client> allClients = Client.GetAll();
        return View["remove_client.cshtml", allClients];
      };
      Post["/delete_stylist"] = _ =>
      {
        Stylist stylistToTerm = Stylist.Find(Request.Form["stylist-id"]);
        stylistToTerm.Delete();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["remove_stylist.cshtml", allStylists];
      };
      Post["/delete_client"] = _ =>
      {
        Client clientToRemove = Client.Find(Request.Form["client-id"]);
        clientToRemove.Delete();
        List<Client> allClients = Client.GetAll();
        return View["remove_client.cshtml", allClients];
      };
      Get["/details/{id}"] = parameters =>
      {
        List<Client> allClients = Client.GetAll();
        IEnumerable<Client> results = allClients.Where(c => c.StylistId == parameters.Id);
        results = results.ToList();
        return View["details.cshtml", results];
      };
      Get["/edit_stylist/{id}"] = parameters =>
      {
        return View["edit_stylist.cshtml", Stylist.Find(parameters.id)];
      };
      Post["/editStylist/{id}"] = parameters =>
      {
        Stylist selectedStyling = Stylist.Find(parameters.id);
        selectedStyling.Update(Request.Form["newname"]);
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
    }
  }
}
