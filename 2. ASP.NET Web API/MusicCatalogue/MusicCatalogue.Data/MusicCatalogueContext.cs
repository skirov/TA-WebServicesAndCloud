using MusicCatalogue.Models;
using System;
using System.Data.Entity;

namespace MusicCatalogue.Data
{
    public class MusicCatalogueContext : DbContext
    {
        public MusicCatalogueContext()
            : base("MusicCatalogueDb")
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums{ get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
