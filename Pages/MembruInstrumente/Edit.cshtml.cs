using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicSchoolWEB.Data;
using MusicSchoolWEB.Models;

namespace MusicSchoolWEB.Pages.MembruInstrumente
{
    public class EditModel : PageModel
    {
        private readonly MusicSchoolWEB.Data.MusicSchoolWEBContext _context;

        public EditModel(MusicSchoolWEB.Data.MusicSchoolWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MembruInstrument MembruInstrument { get; set; } = default!;

        public SelectList MembriList { get; set; }
        public SelectList InstrumenteList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MembruInstrument == null)
            {
                return NotFound();
            }

            var membruinstrument =  await _context.MembruInstrument.FirstOrDefaultAsync(m => m.ID == id);
            if (membruinstrument == null)
            {
                return NotFound();
            }
            MembruInstrument = await _context.MembruInstrument
              .Include(mi => mi.Membru)
              .Include(mi => mi.Intrument)
              .FirstOrDefaultAsync(m => m.ID == id);

            if (MembruInstrument == null)
            {
                return NotFound();
            }

           
            var membri = await _context.Membru
                .Select(m => new
                {
                    ID = m.ID,
                    FullName = m.Nume + " " + m.Prenume
                })
                .ToListAsync();

            MembriList = new SelectList(membri, "ID", "FullName", MembruInstrument.MembruID);
            InstrumenteList = new SelectList(_context.Instrument, "ID", "Nume", MembruInstrument.InstrumentID);

            ViewData["MembruID"] = MembriList;
            ViewData["InstrumentID"] = InstrumenteList;

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

            _context.Attach(MembruInstrument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembruInstrumentExists(MembruInstrument.ID))
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

        private bool MembruInstrumentExists(int id)
        {
            return _context.MembruInstrument.Any(e => e.ID == id);
        }
    }
}
