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

namespace MusicSchoolWEB.Pages.Programari
{
    public class EditModel : PageModel
    {
        private readonly MusicSchoolWEB.Data.MusicSchoolWEBContext _context;

        public EditModel(MusicSchoolWEB.Data.MusicSchoolWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        public SelectList MembriProfesori { get; set; }
        public SelectList MembriStudenti { get; set; }
        public SelectList ProgramariList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }

            
            Programare = await _context.Programare
                .Include(p => p.Teacher)
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Programare == null)
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

            var programari = await _context.Programare
                .Select(p => new
                {
                    ID = p.ID,
                    OraProgramarii = p.OraProgramarii.ToString("g")
                })
                .ToListAsync();

            
            MembriProfesori = new SelectList(membri, "ID", "FullName", Programare.TeacherID);
            MembriStudenti = new SelectList(membri, "ID", "FullName", Programare.StudentID);
            ProgramariList = new SelectList(programari, "ID", "OraProgramarii", Programare.ID);

           
            ViewData["TeacherID"] = MembriProfesori;
            ViewData["StudentID"] = MembriStudenti;
            ViewData["ProgramareID"] = ProgramariList;

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

            _context.Attach(Programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(Programare.ID))
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

        private bool ProgramareExists(int id)
        {
            return _context.Programare.Any(e => e.ID == id);
        }
    }
}
