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
    public class IndexModel : PageModel
    {
        private readonly MusicSchoolWEB.Data.MusicSchoolWEBContext _context;

        public IndexModel(MusicSchoolWEB.Data.MusicSchoolWEBContext context)
        {
            _context = context;
        }

        public IList<MembruInstrument> MembruInstrument { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MembruInstrument = await _context.MembruInstrument
                .Include(m => m.Intrument)
                .Include(m => m.Membru).ToListAsync();
        }
    }
}
