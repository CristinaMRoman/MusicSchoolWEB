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

namespace MusicSchoolWEB.Pages.Feedbacks
{
    public class EditModel : PageModel
    {
        private readonly MusicSchoolWEB.Data.MusicSchoolWEBContext _context;

        public EditModel(MusicSchoolWEB.Data.MusicSchoolWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = default!;

        public SelectList MembriList { get; set; }
        public SelectList ProgramariList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include relatiile pentru a prelua datele corect
            Feedback = await _context.Feedback
                .Include(f => f.Membru)
                .Include(f => f.Programare)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Feedback == null)
            {
                return NotFound();
            }

            // Populam listele pentru dropdown
            var membri = await _context.Membru
                .Select(m => new { m.ID, FullName = m.Nume + " " + m.Prenume })
                .ToListAsync();

            var programari = await _context.Programare
                .Select(p => new { p.ID, OraProgramarii = p.OraProgramarii.ToString("g") })
                .ToListAsync();

            MembriList = new SelectList(membri, "ID", "FullName", Feedback.MembruID);
            ProgramariList = new SelectList(programari, "ID", "OraProgramarii", Feedback.ProgramareID);

            ViewData["MembruID"] = MembriList;
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

            _context.Attach(Feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackExists(Feedback.ID))
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

        private bool FeedbackExists(int id)
        {
            return _context.Feedback.Any(e => e.ID == id);
        }
    }
}
