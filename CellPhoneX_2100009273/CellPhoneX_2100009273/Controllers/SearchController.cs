using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CellPhoneX_2100009273.Models;
using PagedList;

namespace CellPhoneX_2100009273.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        private DBContext db = new DBContext();
        public ActionResult Index(string searchString, int? page)
        {
        
                var pageNumber = page ?? 1;
                var pageSize = 8;
                var products = db.Products.OrderBy(p => p.ProId).Include(b => b.Category);
                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = searchString.ToLower();
                    products = products.Where(b => b.ProName.ToLower().Contains(searchString));
                }
                return View(products.ToPagedList(pageNumber, pageSize));
        }
    }
}