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
    public class IndexModel : PageModel
    {
        private readonly NoBSPlanner.Models.PlannerContext _context;

        public IndexModel(NoBSPlanner.Models.PlannerContext context)
        {
            _context = context;
        }

        public IList<PlannerItem> PlannerItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PlannerItem = await _context.PlannerItems.ToListAsync();
        }
    }
}
