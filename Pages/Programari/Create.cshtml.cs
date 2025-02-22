using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSchoolWEB.Data;
using MusicSchoolWEB.Models;

namespace MusicSchoolWEB.Pages.Programari
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

            var membri = _context.Membru
              .Select(m => new { m.ID, FullName = m.Nume + " " + m.Prenume })
              .ToList();


            ViewData["StudentID"] = new SelectList(_context.Membru, "ID", "FullName");
            ViewData["TeacherID"] = new SelectList(_context.Membru, "ID", "FullName");
            return Page();
        }
        public SelectList MembriProfesori { get; set; }
        public SelectList MembriStudenti { get; set; }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
