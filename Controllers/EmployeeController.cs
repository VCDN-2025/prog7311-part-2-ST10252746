using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Data;
using PROG7311_POE_PART_2.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

[Authorize(Roles = "Employee")]
public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public EmployeeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: /Employee/CreateFarmer
    public IActionResult CreateFarmer()
    {
        return View();
    }

    // POST: /Employee/CreateFarmer
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateFarmer(FarmerViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Farmer");

                var farmer = new Farmer
                {
                    UserId = user.Id,
                    FullName = model.FullName,
                    FarmName = model.FarmName,
                    Location = model.Location
                };

                _context.Farmers.Add(farmer);
                await _context.SaveChangesAsync();

                return RedirectToAction("FarmerCreatedConfirmation");
            }
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    public IActionResult FarmerCreatedConfirmation()
    {
        return View();
    }

    // GET: /Employee/ViewAllProducts
    public async Task<IActionResult> ViewAllProducts(string productType, DateTime? startDate, DateTime? endDate)
    {
        var products = _context.Products.Include(p => p.Farmer).AsQueryable();

        if (!string.IsNullOrEmpty(productType))
            products = products.Where(p => p.Category == productType);

        if (startDate.HasValue)
            products = products.Where(p => p.ProductionDate >= startDate.Value);

        if (endDate.HasValue)
            products = products.Where(p => p.ProductionDate <= endDate.Value);

        return View(await products.ToListAsync());
    }
}