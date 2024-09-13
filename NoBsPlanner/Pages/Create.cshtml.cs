using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NoBSPlanner.Models;

namespace NoBSPlanner.Pages
{
    public class CreateModel : PageModel
    {
        private readonly NoBSPlanner.Models.PlannerContext _context;

        public CreateModel(NoBSPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlannerItem PlannerItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PlannerItems.Add(PlannerItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
