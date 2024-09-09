using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud_Web_App.Data;
using Crud_Web_App.Models;

namespace Crud_Web_App.Controllers
{
    public class ListingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Listings/Index
        public async Task<IActionResult> Index(string searchString, string sortBy)
        {
            var items = await _context.Items.ToListAsync();

            // Преобразуване на Items в Listings
            var listings = items.Select(item => new Listings
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                ImagePath = item.ImagePath
            }).ToList();

            // Логика за филтриране по търсене
            if (!string.IsNullOrEmpty(searchString))
            {
                listings = listings.Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                            || s.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                                   .ToList();
            }

            // Логика за сортиране
            listings = sortBy switch
            {
                "price_desc" => listings.OrderByDescending(s => s.Price).ToList(),
                "price_asc" => listings.OrderBy(s => s.Price).ToList(),
                "name" => listings.OrderBy(s => s.Name).ToList(),
                _ => listings.OrderBy(s => s.Name).ToList(), // Сортиране по име по подразбиране
            };

            return View(listings);
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Listings item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
    }
}
