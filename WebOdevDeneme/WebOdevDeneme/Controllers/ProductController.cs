using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebOdevDeneme.Data;
using WebOdevDeneme.Entity;
using WebOdevDeneme.Models;

namespace WebOdevDeneme.Controllers
{
    public class ProductController : Controller
    {
        readonly ShoppingContext _context;

        public ProductController(ShoppingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(int? id,string q)
        {
            var products = _context.Products;
            var producttypes = _context.ProductTypes;
            var model = new ProductsViewModel()
            {
                Products = products.ToList(),
                ProductTypes = producttypes.ToList()
            };
            return View("Products",model);
        }
        public IActionResult Create()
        {
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(p);
                _context.SaveChanges();
               
                TempData["Message"] = $"{p.Name} isimli ürün eklendi.";
                return RedirectToAction("List");
            }
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId","Name");
            return View();
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Products.Find(id));
        }
        public RedirectToActionResult User()
        {
            return RedirectToAction("Login", "User");
        }
        public IActionResult SelectProducts(int id)
        {
            var products = _context.Products.AsQueryable();
            var producttypes = _context.ProductTypes.AsQueryable();
            products=products.Where(products=>products.ProductTypeId==id);
            var model = new ProductsViewModel()
            {
                Products = products.ToList(),
                ProductTypes = producttypes.ToList()
            };
            if (model.Products.Count==0)
            {
                return View("ürün yok");
            }
            return View("Products",model);
        }
        /*
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId","Name");
            return View(_context.Products.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Update(p);
                return RedirectToAction("List");
            }
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId", "Name");
            return View(p);
        }
        [HttpPost]
        public IActionResult Delete(int ProductId,string Title)
        {
            var entity = _context.Products.Find(ProductId);
            _context.Products.Remove(entity);
            TempData["Message"] = $"{Title} isimli ürün silindi.";
            return RedirectToAction("List");
        }
        */
    }
}
