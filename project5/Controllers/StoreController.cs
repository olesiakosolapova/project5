using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project5.Models;
using System.Data.Entity;


namespace project5.Controllers
{
    public class StoreController : Controller
    {
        //private readonly WatchStoreEntities _db = new WatchStoreEntities();
        BBBContext storedb = new BBBContext();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var variations = storedb.Variations.ToList();
            return View(variations);
        }

        //
        // GET: /Store/Browse
        public ActionResult Browse(string variation)
        {
            var variationModel = storedb.Variations.Include("Watches").Single(v => v.Name == variation);
            return View(variationModel);
        }
        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            var watches = storedb.Watches.Find(id);
            return View(watches);
        }
        [ChildActionOnly]
        public ActionResult VariationMenu()
        {
            var variation = storedb.Variations.ToList();
            return PartialView(variation);
        }
    }
}