using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebOdevDeneme.Data;
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
        public async Task<IActionResult> Index()
        {
            var entity= _context.Products.Include(p => p.ProductTypes);
            return View(await entity.ToListAsync());
        }
        public async Task<IActionResult> ProductList()
        {
            var entity = _context.Products.Include(p => p.ProductTypes);

            return View(await entity.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(p);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{p.Name} isimli ürün eklendi.";
                return RedirectToAction("ProductList");
            }
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId", "Name");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = await  _context.Products.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,Product product)
        {




            var entity =  _context.Products.FirstOrDefault(p=>p.ProductId==id);
                if (entity==null)
                {
                    return NotFound();
                }
                entity.Name = product.Name;
                entity.Description = product.Description;
                entity.ImgURL = product.ImgURL;
                entity.Size = product.Size;
                await _context.SaveChangesAsync();
                return RedirectToAction("ProductList");
            
            ViewBag.ProductTypes = new SelectList(_context.ProductTypes.ToList(), "ProductTypeId", "Name");
            return View();
        }
    }
}
