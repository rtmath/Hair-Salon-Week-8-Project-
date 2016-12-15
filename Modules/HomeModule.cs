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
      Get["/stylist/new"] = _ => View["new_sform.cshtml"];
      Get["/client/new"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["new_cform.cshtml", allStylists];
      };
      Post["/stylist/add"] = _ =>
      {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["new_sform.cshtml"];
      };
      Post["/client/add"] = _ =>
      {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
        newClient.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["new_cform.cshtml", allStylists];
      };
      Get["/stylists/list"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/clients/list"] = _ =>
      {
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };
      Get["/stylist/remove"] = _ =>
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["remove_stylist.cshtml", allStylists];
      };
      Get["/client/remove"] = _ =>
      {
        List<Client> allClients = Client.GetAll();
        return View["remove_client.cshtml", allClients];
      };
      Delete["/stylist/delete"] = _ =>
      {
        Stylist stylistToTerm = Stylist.Find(Request.Form["stylist-id"]);
        stylistToTerm.Delete();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["remove_stylist.cshtml", allStylists];
      };
      Delete["/client/delete"] = _ =>
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
      Get["/stylist/edit/{id}"] = parameters =>
      {
        return View["edit_stylist.cshtml", Stylist.Find(parameters.id)];
      };
      Get["/client/edit/{id}"] = parameters =>
      {
        return View["edit_client.cshtml", Client.Find(parameters.id)];
      };
      Patch["/stylist/update/{id}"] = parameters =>
      {
        Stylist selectedStylist = Stylist.Find(parameters.id);
        selectedStylist.Update(Request.Form["newName"]);
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Patch["/client/update/{id}"] = parameters =>
      {
        Client selectedStyling = Client.Find(parameters.id);
        selectedStyling.Update(Request.Form["newName"]);
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };
    }
  }
}
