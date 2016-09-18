using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class ProjectContext:DbContext
    {
        public ProjectContext():base("name=ProjectContext")
        {

        }

        public DbSet<Paylasimlar> Paylasimlar { get; set; }
        public DbSet<PaylasimTur> PaylasimTur { get; set; }
        public DbSet<Uyeler> Uyeler { get; set; }
        public DbSet<Arkadaslik> Arkadaslik { get; set; }
        public DbSet<Gundem> Gundem { get; set; }
        public DbSet<UGundem> UGundem { get; set; }

    }
}