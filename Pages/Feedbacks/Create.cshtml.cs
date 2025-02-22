using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSchoolWEB.Data;
using MusicSchoolWEB.Models;

namespace MusicSchoolWEB.Pages.Feedbacks
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

            var programari = _context.Programare
                .Select(p => new
                {
                    ID = p.ID,
                    OraProgramarii = p.OraProgramarii.ToString("g") 
                })
                .ToList();

           
            MembriList = new SelectList(membri, "ID", "FullName");
            ProgramariList = new SelectList(programari, "ID", "OraProgramarii");

            // ✅ Corectăm `ViewData`
            ViewData["MembruID"] = MembriList;
            ViewData["ProgramareID"] = ProgramariList;

            return Page();
        }

       
        public SelectList MembriList { get; set; } = default!;
        public SelectList ProgramariList { get; set; } = default!;


        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Feedback.Add(Feedback);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
