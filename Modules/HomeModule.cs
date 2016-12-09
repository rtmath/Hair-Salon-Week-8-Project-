using Nancy;
using System.Collections.Generic;

namespace Salon.Modules
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/new_stylist"] = _ => View["new_sform.cshtml"];
      Get["/new_client"] = _ => View["new_cform.cshtml"];
    }
  }
}
