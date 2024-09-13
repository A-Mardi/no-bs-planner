using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoBSPlanner.Models;

namespace NoBSPlanner.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly NoBSPlanner.Models.PlannerContext _context;

        public DeleteModel(NoBSPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PlannerItem PlannerItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planneritem = await _context.PlannerItems.FirstOrDefaultAsync(m => m.Id == id);

            if (planneritem == null)
            {
                return NotFound();
            }
            else
            {
                PlannerItem = planneritem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planneritem = await _context.PlannerItems.FindAsync(id);
            if (planneritem != null)
            {
                PlannerItem = planneritem;
                _context.PlannerItems.Remove(PlannerItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
