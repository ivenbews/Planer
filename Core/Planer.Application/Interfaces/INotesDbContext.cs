using Microsoft.EntityFrameworkCore;
using Planer.Domain;


namespace Planer.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
