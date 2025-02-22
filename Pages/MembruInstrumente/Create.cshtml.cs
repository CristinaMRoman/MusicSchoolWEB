using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSchoolWEB.Data;
using MusicSchoolWEB.Models;

namespace MusicSchoolWEB.Pages.MembruInstrumente
{
    public class CreateModel : PageModel
    {
        private readonly MusicSchoolWEB.Data.MusicSchoolWEBContext _context;

        public CreateModel(MusicSchoolWEB.Data.MusicSchoolWEBContext context)
        {
            _context = context;
        }

       public IActionResult OnGet()
{
    if (_context == null)
    {
        return NotFound(); 
    }

    var membri = _context.Membru
        .Select(m => new 
        { 
            ID = m.ID, 
            FullName = m.Nume + " " + m.Prenume 
        })
        .ToList();

   
    MembriList = new SelectList(membri, "ID", "FullName");
    InstrumenteList = new SelectList(_context.Instrument.ToList(), "ID", "Nume");

  
    ViewData["InstrumentID"] = InstrumenteList;
    ViewData["MembruID"] = MembriList;

    return Page();
}


public SelectList MembriList { get; set; } = default!;
public SelectList InstrumenteList { get; set; } = default!;


        [BindProperty]
        public MembruInstrument MembruInstrument { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MembruInstrument.Add(MembruInstrument);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
