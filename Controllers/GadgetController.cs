using Microsoft.AspNetCore.Mvc;
using GadgetShop.Models;

namespace GadgetShop.Controllers
{
    public class GadgetController : Controller
    {
        private List<Gadget> GetGadgetList()
        {
            List<Gadget> gadgets = new List<Gadget>();
            List<string> names = new List<string> { "Smartphone", "Headphones", "Smartwatch" };
            List<string> categories = new List<string> { "Mobiles", "Audio", "Wearables" };

            for (int i = 0; i < 3; ++i)
            {
                // picture is drawn by the code itself, so no internet is needed
                string svg = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>" +
                             "<rect width='200' height='200' fill='#d9e6f2'/>" +
                             "<text x='100' y='108' font-size='20' text-anchor='middle' " +
                             "fill='#1f4e79' font-family='Arial'>" + names[i] + "</text></svg>";

                Gadget gadget = new Gadget
                {
                    GId = i + 1,
                    GName = names[i],
                    GCategory = categories[i],
                    GPrice = 15000 + (double)(2500 * i),
                    GImageUrl = "data:image/svg+xml;utf8," + Uri.EscapeDataString(svg)
                };
                gadgets.Add(gadget);
            }
            return gadgets;
        }

        public ActionResult Index()
        {
            var gadgets = GetGadgetList();
            return View("Gadget", gadgets);
        }

        public ActionResult Details(int id)
        {
            var gadgets = GetGadgetList();   // Populate data for this request
            var gadget = gadgets.FirstOrDefault(x => x.GId == id);

            if (gadget == null)
            {
                return NotFound("No gadget found with ID " + id);
            }

            return View("GadgetDetail", gadget);
        }
    }
}
