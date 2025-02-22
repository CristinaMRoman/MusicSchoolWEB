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
    public class DeleteModel : PageModel
    {
        private readonly MusicSchoolWEB.Data.MusicSchoolWEBContext _context;

        public DeleteModel(MusicSchoolWEB.Data.MusicSchoolWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MembruInstrument MembruInstrument { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membruinstrument = await _context.MembruInstrument.FindAsync(id);
            if (membruinstrument != null)
            {
                MembruInstrument = membruinstrument;
                _context.MembruInstrument.Remove(MembruInstrument);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
