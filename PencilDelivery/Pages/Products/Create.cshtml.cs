using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PencilDelivery.Models;

namespace PencilDelivery.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly PencilDelivery.Models.PencilDeliveryContext _context;

        public CreateModel(PencilDelivery.Models.PencilDeliveryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
        ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Id");
        ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
