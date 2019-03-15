using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace Entity
{
    public class DocumentContext : DbContext, IDocumenContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options)
            : base(options)
        { }
        public DbSet<Document> Documents { get; set; }
        public DbSet<TypeofDocument> TypeofDocuments { get; set; }
        public DbSet<User> Users{ get; set; }

        public async Task ContextSaveChangeAsync()
        {
            await SaveChangesAsync();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
        //}
    }

    public interface IDocumenContext       
    {
        DbSet<Document> Documents { get; set; }
        DbSet<TypeofDocument> TypeofDocuments { get; set; }
        DbSet<User> Users { get; set; }
        Task ContextSaveChangeAsync();
    }
}
