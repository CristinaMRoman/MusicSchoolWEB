using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicSchoolWEB.Data;
using MusicSchoolWEB.Models;

namespace MusicSchoolWEB.Pages.MembruInstrumente
{
    public class DetailsModel : PageModel
    {
        private readonly MusicSchoolWEB.Data.MusicSchoolWEBContext _context;

        public DetailsModel(MusicSchoolWEB.Data.MusicSchoolWEBContext context)
        {
            _context = context;
        }

        public MembruInstrument MembruInstrument { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembruInstrument = await _context.MembruInstrument
             .Include(mi => mi.Membru)
             .Include(mi => mi.Intrument)
             .FirstOrDefaultAsync(m => m.ID == id);

            var membruinstrument = await _context.MembruInstrument.FirstOrDefaultAsync(m => m.ID == id);
            if (membruinstrument == null)
            {
                return NotFound();
            }
            else
            {
                MembruInstrument = membruinstrument;
            }
            return Page();
        }
    }
}
