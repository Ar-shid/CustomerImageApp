using CustomerImageApp.Data;
using CustomerImageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerImageApp.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;

        public CustomerController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var customers = await _db.Customers
                .Include(c => c.Images)
                .ToListAsync();
            return View(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _db.Customers
                .Include(c => c.Images)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost("{id}/upload")]
        public async Task<IActionResult> Upload(int id, List<IFormFile> files)
        {
            var customer = await _db.Customers
                .Include(c => c.Images)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                return NotFound();

            if (customer.Images.Count + files.Count > 10)
            {
                TempData["Error"] = $"You can only upload up to 10 images per customer. " +
                                    $"You already have {customer.Images.Count}.";
                return RedirectToAction("Details", new { id });
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    string base64 = Convert.ToBase64String(ms.ToArray());

                    customer.Images.Add(new CustomerImage
                    {
                        Base64Image = base64
                    });
                }
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("Details", new { id });
        }

        [HttpPost("{customerId}/delete/{imageId}")]
        public async Task<IActionResult> DeleteImage(int customerId, int imageId)
        {
            var image = await _db.CustomerImages
                .FirstOrDefaultAsync(x => x.CustomerId == customerId && x.Id == imageId);

            if (image == null)
                return NotFound();

            _db.CustomerImages.Remove(image);
            await _db.SaveChangesAsync();

            return RedirectToAction("Details", new { id = customerId });
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

