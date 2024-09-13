using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NoBSPlanner.Models;

namespace NoBSPlanner.Pages
{
    public class EditModel : PageModel
    {
        private readonly NoBSPlanner.Models.PlannerContext _context;

        public EditModel(NoBSPlanner.Models.PlannerContext context)
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

            var planneritem =  await _context.PlannerItems.FirstOrDefaultAsync(m => m.Id == id);
            if (planneritem == null)
            {
                return NotFound();
            }
            PlannerItem = planneritem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PlannerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlannerItemExists(PlannerItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlannerItemExists(int id)
        {
            return _context.PlannerItems.Any(e => e.Id == id);
        }
    }
}
