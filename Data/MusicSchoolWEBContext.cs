using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicSchoolWEB.Models;

namespace MusicSchoolWEB.Data
{
    public class MusicSchoolWEBContext : DbContext
    {
        public MusicSchoolWEBContext (DbContextOptions<MusicSchoolWEBContext> options)
            : base(options)
        {
        }

        public DbSet<MusicSchoolWEB.Models.Membru> Membru { get; set; } = default!;
        public DbSet<MusicSchoolWEB.Models.Instrument> Instrument { get; set; } = default!;
        public DbSet<MusicSchoolWEB.Models.Programare> Programare { get; set; } = default!;
        public DbSet<MusicSchoolWEB.Models.MembruInstrument> MembruInstrument { get; set; } = default!;
        public DbSet<MusicSchoolWEB.Models.Feedback> Feedback { get; set; } = default!;
    }
}
