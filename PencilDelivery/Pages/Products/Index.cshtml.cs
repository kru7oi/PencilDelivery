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
        

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Include(p => p.Unit).ToListAsync();

            Category = await _context.Categories.ToListAsync();
        }
    }
}
