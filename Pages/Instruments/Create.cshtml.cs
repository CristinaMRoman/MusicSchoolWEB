﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicSchoolWEB.Data;
using MusicSchoolWEB.Models;

namespace MusicSchoolWEB.Pages.Instruments
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
            return Page();
        }

        [BindProperty]
        public Instrument Instrument { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Instrument.Add(Instrument);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
