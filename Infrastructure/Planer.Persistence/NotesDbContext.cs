using Microsoft.EntityFrameworkCore;
using Planer.Application.Interfaces;
using Planer.Domain;
using Planer.Persistence.EntityTypeConfiguration;

namespace Planer.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) { }

        public Task<int> SaveChangesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
