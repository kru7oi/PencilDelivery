using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PencilDelivery.Models;

namespace PencilDelivery.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PencilDelivery.Models.PencilDeliveryContext _context;

        public IndexModel(PencilDelivery.Models.PencilDeliveryContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        public IList<Category> Category { get;set; } = default!;
        public IList<Photo> Photo { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public Category SelectedCategory { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Category = await _context.Categories.ToListAsync();

            Photo = await _context.Photos
                .Include(p => p.Product).ToListAsync();

            if (!string.IsNullOrEmpty(SearchString))
            {
                Product = await _context.Products
                    .Where(p => p.Title.Contains(SearchString)).ToListAsync();
            }
            else
            {
                Product = await _context.Products.ToListAsync();
            }


            if (id != null)
            {
                SelectedCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

                Product = await _context.Products
                        .Where(p => p.CategoryId == SelectedCategory.Id).ToListAsync();
            }

            return Page();
        }
    }
}
