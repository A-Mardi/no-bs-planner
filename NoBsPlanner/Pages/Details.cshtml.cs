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
    public class DetailsModel : PageModel
    {
        private readonly NoBSPlanner.Models.PlannerContext _context;

        public DetailsModel(NoBSPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

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
    }
}
