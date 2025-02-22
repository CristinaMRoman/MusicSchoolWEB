using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicSchoolWEB.Data;
using MusicSchoolWEB.Models;

namespace MusicSchoolWEB.Pages.Membri
{
    public class IndexModel : PageModel
    {
        private readonly MusicSchoolWEB.Data.MusicSchoolWEBContext _context;

        public IndexModel(MusicSchoolWEB.Data.MusicSchoolWEBContext context)
        {
            _context = context;
        }

        public IList<Membru> Membru { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Membru = await _context.Membru.ToListAsync();
        }
    }
}
