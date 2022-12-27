using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebOdevDeneme.Data;
using WebOdevDeneme.Entity;
using WebOdevDeneme.Models;

namespace WebOdevDeneme.Controllers
{
    public class AdminController : Controller
    {
        private readonly ShoppingContext _context;
        public AdminController(ShoppingContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductList()
        {
            ViewBag.ProductTypes = _context.ProductTypes.ToList();
            
            return View(new AdminProductsViewModel
            {
                Products = _context.Products.ToList()
            }); ;
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
                return RedirectToAction("ProductList");
            }
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {

            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId", "Name");
            var entity = _context.Products.Select(p => new AdminProductEditViewModel
            {
                ProductId = p.ProductId,
                Name=p.Name,
                Description=p.Description,
                ProductTypeId=p.ProductTypeId,
                ImgURL=p.ImgURL,
                Size=p.Size
            });

            return View(entity);
        }
        [HttpPost]
        public IActionResult Update(AdminProductEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                var entity= _context.Products.Find(model.ProductId);
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.ProductTypeId = model.ProductTypeId;
                entity.ImgURL = model.ImgURL;
                entity.Size = model.Size;
                _context.SaveChanges();
                return RedirectToAction("ProductList");
            }
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId", "Name");
            return View();
        }
    }
}
